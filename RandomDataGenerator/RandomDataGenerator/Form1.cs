using FizzWare.NBuilder;
using Oracle.ManagedDataAccess.Client;
using RandomDataGenerator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace RandomDataGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random random = new Random();

        private void ReservationButton_Click(object sender, EventArgs e)
        {
            var numberGen = new RandomGenerator();

            var value = ValueTextbox.Text;

            bool convert = Int32.TryParse(value, out int recordNumbers);

            if (convert)
            {
                try
                {
                    using (var context = new Aplikacje_bazodanoweContext())
                    {

                        if (!context.Tflight.Any() || !context.Thotel.Any())
                        {
                            MessageBox.Show("Najpierw dodaj samoloty oraz hotele");
                        }
                        else
                        {
                            BuilderSetup.DisablePropertyNamingFor<Tbookelement, int>(x => x.Id);
                            BuilderSetup.DisablePropertyNamingFor<Tbooking, int>(x => x.Id);
                            BuilderSetup.DisablePropertyNamingFor<Tbooking, string>(x => x.Bookno);
                            BuilderSetup.DisablePropertyNamingFor<Tbookingpax, int>(x => x.Id);
                            BuilderSetup.DisablePropertyNamingFor<Tcustomer, int>(x => x.Id);


                            var customers = Builder<Tcustomer>.CreateListOfSize(recordNumbers).
                                All()
                                .With(r => r.Points = numberGen.Next(1, 100))
                                .With(r => r.Dob = Faker.Identification.DateOfBirth())
                                .With(r => r.Phone = ConvertPhoneNumer(Faker.Phone.Number()))
                                .With(r => r.Pesel = Faker.Identification.BulgarianPin())
                                .With(r => r.Email = Faker.Internet.Email())
                                .With(r => r.Firstname = Faker.Name.First())
                                .With(r => r.Lastname = Faker.Name.Last())
                                .With(r => r.CreateUser = Faker.Name.First())
                                .With(r => r.Rowversion = numberGen.Next(1, 100))
                                .With(r => r.UpdateDate = DateTime.Now.AddDays(-numberGen.Next(1, 100)))
                                .With(r => r.UpdateUser = Faker.Name.First())
                                .Build();

                            context.Tcustomer.AddRange(customers);
                            context.SaveChanges();

                            //Narazie nie zapisujemy wygenerowanych rekordów do bazy, bo trzeba im najpierw wyliczyć cenę
                            var bookings = Builder<Tbooking>.CreateListOfSize(recordNumbers)
                                .All()
                                .With(b => b.Tcustomer = Pick<Tcustomer>.RandomItemFrom(context.Tcustomer.ToList()))
                                .With(b => b.Tbookstate = Pick<Tbookstate>.RandomItemFrom(context.Tbookstate.ToList()))
                                .With(b => b.Booked = random.Next(0, 2))
                                .With(b => b.CreateUser = Faker.Name.First())
                                .With(b => b.Rowversion = numberGen.Next(1, 100))
                                .With(b => b.UpdateDate = DateTime.Now.AddDays(-numberGen.Next(1, 100)))
                                .With(b => b.UpdateUser = Faker.Name.First())
                                .Build();

                            bookings.ToList().ForEach(booking =>
                            {
                                //Dla każdej rezerwacji najpierw dodajemy pasażerów w ilości od 1 do 10
                                var paxNumbers = numberGen.Next(1, 10);

                                IList<Tbookingpax> passengers;

                                //Losujemy czy w liście paxów ma się znaleźć płatnik czy nie
                                if (random.Next(0, 2) == 0)
                                {
                                    passengers = Builder<Tbookingpax>.CreateListOfSize(paxNumbers)
                                    .All()
                                    .With(p => p.IsCustomer = 0) //Domyślnie nikt nie jest płatnikiem, losujemy potem jedną osobę która nim zostanie
                                    .With(p => p.Tbooking = booking)
                                    .With(p => p.Firstname = Faker.Name.First())
                                    .With(p => p.Lastname = Faker.Name.Last())
                                    .With(p => p.CreateUser = Faker.Name.First())
                                    .With(p => p.Pesel = Faker.Identification.BulgarianPin())
                                    .With(p => p.Rowversion = numberGen.Next(1, 100))
                                    .With(p => p.UpdateDate = DateTime.Now.AddDays(-numberGen.Next(1, 100)))
                                    .With(p => p.UpdateUser = Faker.Name.First())
                                    .Random(1)
                                    .With(p => p.IsCustomer = 1) // 1 lub 0 osób będą płatnikami na liście paxów
                                    .Build();
                                }
                                else
                                {

                                    passengers = Builder<Tbookingpax>.CreateListOfSize(paxNumbers)
                                    .All()
                                    .With(p => p.IsCustomer = 0) //Domyślnie nikt nie jest płatnikiem, losujemy potem jedną osobę która nim zostanie
                                    .With(p => p.Tbooking = booking)
                                    .With(p => p.Pesel = Faker.Identification.BulgarianPin())
                                    .With(p => p.Firstname = Faker.Name.First())
                                    .With(p => p.Lastname = Faker.Name.Last())
                                    .With(p => p.CreateUser = Faker.Name.First())
                                    .With(p => p.Rowversion = numberGen.Next(1, 100))
                                    .With(p => p.UpdateDate = DateTime.Now.AddDays(-numberGen.Next(1, 100)))
                                    .With(p => p.UpdateUser = Faker.Name.First())
                                    .Build();
                                }


                                context.Tbookingpax.AddRange(passengers);

                                //Losujemy rodzaj wycieczki (tylko przelot/ przelot+hotel / sam hotel)
                                var triptype = (TripTypeEnum)random.Next(0, 3); //0 - 3

                                Tbookelement hotel;
                                Tbookelement flight;
                                decimal elementsTotalPrice = 0;

                                var t = Builder<Tbookelement>.CreateNew().Build();
                                switch (triptype)
                                {

                                    case TripTypeEnum.HotelFlight:

                                        hotel = Builder<Tbookelement>.CreateNew()
                                        .With(e => e.Tbooking = booking)
                                        .With(e => e.Thotel = Pick<Thotel>.RandomItemFrom(context.Thotel.ToList()))
                                        .With(e => e.CreateUser = Faker.Name.First())
                                        .With(e => e.Tflight = null)
                                        .With(e => e.TflightId = null)
                                        .With(e => e.TbookeltypeId = null)
                                        .With(e => e.Rowversion = numberGen.Next(1, 100))
                                        .With(e => e.UpdateDate = DateTime.Now.AddDays(-numberGen.Next(1, 100)))
                                        .With(e => e.UpdateUser = Faker.Name.First())
                                        .Build();

                                        flight = Builder<Tbookelement>.CreateNew()
                                        .With(e => e.Tbooking = booking)
                                        .With(e => e.Tflight = Pick<Tflight>.RandomItemFrom(context.Tflight.ToList()))
                                        .With(e => e.Thotel = null)
                                        .With(e => e.ThotelId = null)
                                        .With(e => e.TbookeltypeId = null)
                                        .With(e => e.CreateUser = Faker.Name.First())
                                        .With(e => e.Rowversion = numberGen.Next(1, 100))
                                        .With(e => e.UpdateDate = DateTime.Now.AddDays(-numberGen.Next(1, 100)))
                                        .With(e => e.UpdateUser = Faker.Name.First())
                                        .Build();

                                        elementsTotalPrice = flight.Tflight.Price.Value + hotel.Thotel.Price;

                                        context.Tbookelement.Add(hotel);
                                        context.Tbookelement.Add(flight);
                                        break;
                                    case TripTypeEnum.Hotel:
                                        hotel = Builder<Tbookelement>.CreateNew()
                                        .With(e => e.Tbooking = booking)
                                        .With(e => e.Thotel = Pick<Thotel>.RandomItemFrom(context.Thotel.ToList()))
                                        .With(e => e.Tflight = null)
                                        .With(e => e.TflightId = null)
                                        .With(e => e.TbookeltypeId = null)
                                        .With(e => e.CreateUser = Faker.Name.First())
                                        .With(e => e.Rowversion = numberGen.Next(1, 100))
                                        .With(e => e.UpdateDate = DateTime.Now.AddDays(-numberGen.Next(1, 100)))
                                        .With(e => e.UpdateUser = Faker.Name.First())
                                        .Build();

                                        context.Tbookelement.Add(hotel);

                                        elementsTotalPrice = hotel.Thotel.Price;
                                        break;
                                    case TripTypeEnum.Flight:
                                        flight = Builder<Tbookelement>.CreateNew()
                                        .With(e => e.Tbooking = booking)
                                        .With(e => e.Tflight = Pick<Tflight>.RandomItemFrom(context.Tflight.ToList()))
                                        .With(e => e.CreateUser = Faker.Name.First())
                                        .With(e => e.Thotel = null)
                                        .With(e => e.ThotelId = null)
                                        .With(e => e.TbookeltypeId = null)
                                        .With(e => e.Rowversion = numberGen.Next(1, 100))
                                        .With(e => e.UpdateDate = DateTime.Now.AddDays(-numberGen.Next(1, 100)))
                                        .With(e => e.UpdateUser = Faker.Name.First())
                                        .Build();

                                        context.Tbookelement.Add(flight);

                                        elementsTotalPrice = flight.Tflight.Price.Value;
                                        break;
                                }

                                //Zapisujemy cene total na rezerwacji
                                booking.TotalPrice = elementsTotalPrice;
                            });

                            //Na końcu zapisujemy wszystkie dane do bazy
                            context.Tbooking.AddRange(bookings);
                            context.SaveChanges();

                            MessageBox.Show("Poprawnie dodano rekordy");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bład podczas zapisu danych do bazy: {ex.Message}");
                }

            }
            else
            {
                MessageBox.Show("Podaj poprawną liczbę");
            }
        }

        private int GetNextSequenceValue()
        {
            throw new NotImplementedException();
        }

        //Ucinamy długość numerów ze względu na pole w bazie
        private string ConvertPhoneNumer(string number) => number.Length > 20 ? number.Substring(0, 20) : number;

        private void UsersButton_Click(object sender, EventArgs e)
        {
            var numberGen = new RandomGenerator();

            var value = ValueTextbox.Text;

            bool convert = Int32.TryParse(value, out int recordNumbers);

            if (convert)
            {

                try
                {
                    using (var context = new Aplikacje_bazodanoweContext())
                    {
                        BuilderSetup.DisablePropertyNamingFor<Tuser, int>(x => x.Id);
                        BuilderSetup.DisablePropertyNamingFor<Tusergroup, int>(x => x.Id);
                        BuilderSetup.DisablePropertyNamingFor<Tgroup, int>(x => x.Id);

                        var groups = Builder<Tgroup>.CreateListOfSize(recordNumbers)
                            .All()
                            .With(c => c.Deleted = random.Next(0, 2))
                            .With(c => c.System = random.Next(0, 2))
                            .With(c => c.Name = "Group" + Guid.NewGuid().ToString())
                            .With(c => c.CreateUser = Faker.Name.First())
                            .With(c => c.UpdateUser = Faker.Name.Last())
                            .With(c => c.Rowversion = numberGen.Next(1, 100))
                            .With(c => c.UpdateDate = DateTime.Now.AddDays(-numberGen.Next(1, 100)))
                            .Build();

                        context.Tgroup.AddRange(groups);
                        context.SaveChanges();

                        var users = Builder<Tuser>.CreateListOfSize(recordNumbers).
                            All()
                            .With(r => r.Deleted = random.Next(0, 2))
                            .With(r => r.Email = Faker.Internet.Email())
                            .With(r => r.Name = Faker.Name.FullName())
                            .With(r => r.CreateUser = Faker.Name.First())
                            .With(r => r.Rowversion = numberGen.Next(1, 100))
                            .With(r => r.UpdateDate = DateTime.Now.AddDays(-numberGen.Next(1, 100)))
                            .With(r => r.UpdateUser = Faker.Name.First())
                            .Build();

                        context.Tuser.AddRange(users.ToList());
                        context.SaveChanges();

                        //Dla każdego usera losujemy od 1 do 5 grup użytkownika
                        users.ToList().ForEach(user =>
                        {
                            int groupNumber = numberGen.Next(1, 5);

                            //Losujemy unikalne grupy w losowej ilości
                            var groupList = new List<Tgroup>(Pick<Tgroup>.UniqueRandomList(groupNumber).From(context.Tgroup.ToList()));

                            var usergroup = Builder<Tusergroup>.CreateListOfSize(groupNumber)
                            .All()
                            .With(g => g.Tuser = user)
                            .With(g => g.Tgroup = groupList.PopAt(0))
                            .With(g => g.Rowversion = numberGen.Next(1, 100))
                            .With(g => g.UpdateDate = DateTime.Now.AddDays(-numberGen.Next(1, 100)))
                            .With(g => g.UpdateUser = Faker.Name.First())
                            .Build();

                            context.Tusergroup.AddRange(usergroup);

                        });

                        context.SaveChanges();
                    }

                    MessageBox.Show("Poprawnie dodano rekordy");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bład podczas zapisu danych do bazy: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Podaj poprawną liczbę");
            }
        }

        private void RegionButton_Click(object sender, EventArgs e)
        {
            //            OracleConnection con = new OracleConnection();
            //     //       con.ConnectionString = "user id=s95571;password=rg45a!kahe75;data source=" +
            //     //"(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)" +
            //     //"(HOST=217.173.198.135)(PORT=1522))(CONNECT_DATA=" +
            //     //"(SERVICE_NAME=orcltp)))";
            //            con.ConnectionString = @"User Id=s95571;Password=rg45a!kahe75;Data Source=(DESCRIPTION =
            //(ADDRESS_LIST =
            //(ADDRESS =
            //(COMMUNITY = TCP)
            //(PROTOCOL = TCP)
            //(HOST = 217.173.198.135)
            //(PORT = 1522)
            //)
            //)
            //(CONNECT_DATA = (SID = orcltp))
            //)";
            //            try
            //            {
            //                con.Open();

            //            }
            //            catch(Exception ex)
            //            {
            //                Console.WriteLine();
            //            }

            var numberGen = new RandomGenerator();

            var value = ValueTextbox.Text;

            bool convert = Int32.TryParse(value, out int recordNumbers);

            if (convert)
            {
                try
                {
                    using (var context = new Aplikacje_bazodanoweContext())
                    {
                        BuilderSetup.DisablePropertyNamingFor<Tcountry, int>(x => x.Id);
                        BuilderSetup.DisablePropertyNamingFor<Tregion, int>(x => x.Id);

                        var countries = Builder<Tcountry>.CreateListOfSize(recordNumbers)
                            .All()
                            .With(c => c.Name = Faker.Country.Name())
                            .With(c => c.Code = Faker.Country.TwoLetterCode())
                            .With(c => c.CreateUser = Faker.Name.First())
                            .With(c => c.UpdateUser = Faker.Name.Last())
                            .With(c => c.Rowversion = numberGen.Next(1, 100))
                            .With(c => c.UpdateDate = DateTime.Now.AddDays(-numberGen.Next(1, 100)))
                            .Build();

                        context.Tcountry.AddRange(countries);
                        context.SaveChanges();

                        var countryList = new List<Tcountry>(Pick<Tcountry>.UniqueRandomList(recordNumbers).From(context.Tcountry.ToList()));

                        var regions = Builder<Tregion>.CreateListOfSize(recordNumbers).
                            All()
                            .With(r => r.CreateUser = Faker.Name.First())
                            .With(r => r.Tcountry = countryList.PopAt(0))
                            .With(r => r.Rowversion = numberGen.Next(1, 100))
                            .With(r => r.UpdateDate = DateTime.Now.AddDays(-numberGen.Next(1, 100)))
                            .With(r => r.CreateUser = Faker.Name.First())
                            .With(r => r.Name = "Region " + Guid.NewGuid().ToString())
                            .Build();

                        context.Tregion.AddRange(regions);
                        context.SaveChanges();
                    }

                    MessageBox.Show("Poprawnie dodano rekordy");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bład podczas zapisu danych do bazy: {ex.Message}");
                }

            }
            else
            {
                MessageBox.Show("Podaj poprawną liczbę");
            }
        }

        private string RandomCode(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void FlightsButton_Click(object sender, EventArgs e)
        {
            var numberGen = new RandomGenerator();

            var value = ValueTextbox.Text;

            bool convert = Int32.TryParse(value, out int recordNumbers);

            if (convert)
            {
                try
                {
                    using (var context = new Aplikacje_bazodanoweContext())
                    {
                        BuilderSetup.DisablePropertyNamingFor<Tflight, int>(x => x.Id);

                        var flights = Builder<Tflight>.CreateListOfSize(recordNumbers).
                          All()
                          .With(f => f.Price = numberGen.Next(1000, 5000))
                          .With(f => f.Code = RandomCode(6))
                          .With(f => f.ArrivalDate = DateTime.Today.AddDays(numberGen.Next(5, 720)))
                          .With(f => f.DepartureDate = f.ArrivalDate.Value.AddDays(-numberGen.Next(3, 14))) //Data wylotu musi być wcześniejsza niż data przylotu
                          .With(f => f.Handbag = numberGen.Next(5, 20))
                          .With(f => f.Regbag = numberGen.Next(5, 20))
                          .With(f => f.Regbagnum = numberGen.Next(1, 3))
                          .With(f => f.Handbagnum = numberGen.Next(1, 3))
                          .With(f => f.CreateUser = Faker.Name.First())
                          .With(f => f.Rowversion = numberGen.Next(1, 100))
                          .With(f => f.UpdateDate = DateTime.Now.AddDays(-numberGen.Next(1, 100)))
                          .With(f => f.UpdateUser = Faker.Name.First())
                          .Build();

                        context.Tflight.AddRange(flights);
                        context.SaveChanges();
                    }

                    MessageBox.Show("Poprawnie dodano rekordy");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bład podczas zapisu danych do bazy: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Podaj poprawną liczbę");
            }
        }

        private void HotelsButton_Click(object sender, EventArgs e)
        {
            var numberGen = new RandomGenerator();

            var value = ValueTextbox.Text;

            bool convert = Int32.TryParse(value, out int recordNumbers);

            if (convert)
            {
                try
                {
                    using (var context = new Aplikacje_bazodanoweContext())
                    {

                        if (!context.Tregion.ToList().Any())
                        {
                            MessageBox.Show("Proszę najpierw utworzyć regiony");
                        }
                        else
                        {
                            BuilderSetup.DisablePropertyNamingFor<Thotel, int>(x => x.Id);
                            BuilderSetup.DisablePropertyNamingFor<Thotelinfo, int>(x => x.Id);

                            var hotels = Builder<Thotel>.CreateListOfSize(recordNumbers).
                              All()
                              .With(h => h.Name = "Hotel " + RandomCode(numberGen.Next(1, 8)))
                              .With(h => h.Price = numberGen.Next(1000, 5000))
                              .With(h => h.Roomsamounttotal = numberGen.Next(0, 100))
                              .With(h => h.Roomsamountleft = numberGen.Next(0, h.Roomsamounttotal.Value)) //Nie może być więcej miejsc wolnych i dopuszczalnych
                              .With(h => h.Tregion = Pick<Tregion>.RandomItemFrom(context.Tregion.ToList()))
                              .With(h => h.CreateUser = Faker.Name.First())
                              .With(h => h.Rowversion = numberGen.Next(1, 100))
                              .With(h => h.UpdateDate = DateTime.Now.AddDays(-numberGen.Next(1, 100)))
                              .With(h => h.UpdateUser = Faker.Name.First())
                              .Build();

                            context.Thotel.AddRange(hotels.ToList());
                            context.SaveChanges();

                            hotels.ToList().ForEach(hotel =>
                            {
                                int languagueNumber = context.Tlanguage.Count();

                                var languagueList = context.Tlanguage.ToList();

                                var hotelinfo = Builder<Thotelinfo>.CreateListOfSize(languagueNumber)
                                .All()
                                .With(h => h.Description = Faker.Lorem.Sentence())
                                .With(h => h.Tlanguage = languagueList.PopAt(0))
                                .With(h => h.Thotel = hotel)
                                .With(h => h.CreateUser = Faker.Name.First())
                                .With(h => h.Rowversion = numberGen.Next(1, 100))
                                .With(h => h.UpdateDate = DateTime.Now.AddDays(-numberGen.Next(1, 100)))
                                .With(h => h.UpdateUser = Faker.Name.First())
                                .Build();

                                context.Thotelinfo.AddRange(hotelinfo);
                                context.SaveChanges();
                            });
                        }
                    }

                    MessageBox.Show("Poprawnie dodano rekordy");

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bład podczas zapisu danych do bazy: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Podaj poprawną liczbę");
            }
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new Aplikacje_bazodanoweContext())
                {
                    int exportCoutner = 0;

                    if (tbookelement_cb.Checked)
                    {
                        var data = context.Tbookelement.ToList();

                        ExportTable("Tbookelement_data.xml", data);

                        exportCoutner++;
                    }

                    if (tbooking_cb.Checked)
                    {
                        var t = context.Tbooking.FirstOrDefault(x => x.Id == 11);
                        var data = context.Tbooking.ToList();

                        ExportTable("Tboooking_data.xml", data);

                        exportCoutner++;
                    }

                    if (tbookingpax_cb.Checked)
                    {
                        var data = context.Tbookingpax.ToList();

                        ExportTable("Tbookingpax_data.xml", data);

                        exportCoutner++;
                    }

                    if (tbookstate_cb.Checked)
                    {
                        var data = context.Tbookstate.ToList();

                        ExportTable("Tbookstate_data.xml", data);

                        exportCoutner++;
                    }

                    if (tcountry_cb.Checked)
                    {
                        var data = context.Tcountry.ToList();

                        ExportTable("Tcountry_data.xml", data);

                        exportCoutner++;
                    }

                    if (tcustomer_cb.Checked)
                    {
                        var data = context.Tcustomer.ToList();

                        ExportTable("Tcustomer_data.xml", data);

                        exportCoutner++;
                    }

                    if (tflight_cb.Checked)
                    {
                        var data = context.Tflight.ToList();

                        ExportTable("Tflight_data.xml", data);

                        exportCoutner++;
                    }

                    if (tgroup_cb.Checked)
                    {
                        var data = context.Tgroup.ToList();

                        ExportTable("Tgroup_data.xml", data);

                        exportCoutner++;
                    }

                    if (thotel_cb.Checked)
                    {
                        var data = context.Thotel.ToList();

                        ExportTable("Thotel_data.xml", data);

                        exportCoutner++;
                    }

                    if (thotelinfo_cb.Checked)
                    {
                        var data = context.Thotelinfo.ToList();

                        ExportTable("Thotelinfo_data.xml", data);

                        exportCoutner++;
                    }

                    if (tlanguage_cb.Checked)
                    {
                        var data = context.Tlanguage.ToList();

                        ExportTable("Tlanguage_data.xml", data);

                        exportCoutner++;
                    }

                    if (tregion_cb.Checked)
                    {
                        var data = context.Tregion.ToList();

                        ExportTable("Tregion_data.xml", data);

                        exportCoutner++;
                    }

                    if (tuser_cb.Checked)
                    {
                        var data = context.Tuser.ToList();

                        ExportTable("Tuser_data.xml", data);

                        exportCoutner++;
                    }

                    if (tusergroup_cb.Checked)
                    {
                        var data = context.Tusergroup.ToList();

                        ExportTable("Tusergroup_data.xml", data);

                        exportCoutner++;
                    }

                    MessageBox.Show(@$"Finished exporting {exportCoutner} files!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@$"Error: {ex.Message}");
            }
        }

        private string getExportPath => @"C:\Studia\XML\";

        private void ExportTable<T>(string fileName, List<T> data)
        {
            Serializator.Serialize<T>(string.Concat(getExportPath, @"\", fileName), data);
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            openFile.DefaultExt = "*.xml";
            openFile.Multiselect = true;

            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               openFile.FileName.Length > 0)
            {
                using (var context = new Aplikacje_bazodanoweContext())
                {
                    try
                    {
                        foreach (var fileName in openFile.SafeFileNames)
                        {
                            switch (fileName)
                            {
                                case "Tbookelement_data.xml":
                                    var data = LoadXmlFile<Tbookelement>(string.Concat(getExportPath, @"\", fileName));
                                    context.Tbookelement.AddRange(data);
                                    context.SaveChanges();
                                    break;
                                case "Tbooking_data.xml":
                                    var bookings = LoadXmlFile<Tbooking>(string.Concat(getExportPath, @"\", fileName));
                                    context.Tbooking.AddRange(bookings);
                                    context.SaveChanges();
                                    break;
                                case "Tbookingpax_data.xml":
                                    var paxes = LoadXmlFile<Tbookingpax>(string.Concat(getExportPath, @"\", fileName));
                                    context.Tbookingpax.AddRange(paxes);
                                    context.SaveChanges();
                                    break;
                                case "Tbookstate_data.xml":
                                    var states = LoadXmlFile<Tbookstate>(string.Concat(getExportPath, @"\", fileName));
                                    context.Tbookstate.AddRange(states);
                                    context.SaveChanges();
                                    break;
                                case "Tcountry_data.xml":
                                    var countries = LoadXmlFile<Tcountry>(string.Concat(getExportPath, @"\", fileName));
                                    context.Tcountry.AddRange(countries);
                                    context.SaveChanges();
                                    break;
                                case "Tcustomer_data.xml":
                                    var customers = LoadXmlFile<Tcustomer>(string.Concat(getExportPath, @"\", fileName));
                                    context.Tcustomer.AddRange(customers);
                                    context.SaveChanges();
                                    break;
                                case "Tflight_data.xml":
                                    var flights = LoadXmlFile<Tflight>(string.Concat(getExportPath, @"\", fileName));
                                    context.Tflight.AddRange(flights);
                                    context.SaveChanges();
                                    break;
                                case "Tgroup_data.xml":
                                    var groups = LoadXmlFile<Tgroup>(string.Concat(getExportPath, @"\", fileName));
                                    context.Tgroup.AddRange(groups);
                                    context.SaveChanges();
                                    break;
                                case "Thotel_data.xml":
                                    var hotels = LoadXmlFile<Thotel>(string.Concat(getExportPath, @"\", fileName));
                                    context.Thotel.AddRange(hotels);
                                    context.SaveChanges();
                                    break;
                                case "Thotelinfo_data.xml":
                                    var hotelinfo = LoadXmlFile<Thotelinfo>(string.Concat(getExportPath, @"\", fileName));
                                    context.Thotelinfo.AddRange(hotelinfo);
                                    context.SaveChanges();
                                    break;
                                case "Tlanguage_data.xml":
                                    var languagues = LoadXmlFile<Tlanguage>(string.Concat(getExportPath, @"\", fileName));
                                    context.Tlanguage.AddRange(languagues);
                                    context.SaveChanges();
                                    break;
                                case "Tregion_data.xml":
                                    var regions = LoadXmlFile<Tregion>(string.Concat(getExportPath, @"\", fileName));
                                    context.Tregion.AddRange(regions);
                                    context.SaveChanges();
                                    break;
                                case "Tuser_data.xml":
                                    var users = LoadXmlFile<Tuser>(string.Concat(getExportPath, @"\", fileName));
                                    context.Tuser.AddRange(users);
                                    context.SaveChanges();
                                    break;
                                case "Tusergroup_data.xml":
                                    var usergroups = LoadXmlFile<Tusergroup>(string.Concat(getExportPath, @"\", fileName));
                                    context.Tusergroup.AddRange(usergroups);
                                    context.SaveChanges();
                                    break;

                                default:
                                    break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(@$"Error when importing files: {ex.InnerException}");
                    }
                }
            }
        }

        private List<T> LoadXmlFile<T>(string fileName)
        {
            return Serializator.Deserialize<T>(fileName).ToList();
        }
    }
}