using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;
using WebApplication1.Services;
using static WebApplication1.Pages.Main.IndexModel;

namespace WebApplication1.Pages.DataEntry
{
    public class CreateModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly ApplicationDbContext context;

        [BindProperty]
        public DataEntryDto DataEntryDto { get; set; } = new DataEntryDto();

        public CreateModel(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }
        public void OnGet()
        {
        }

        public string errorMessage = "";
        public string successMessage = "";

        public void OnPost()
        {
            if (DataEntryDto.KTPFile == null)
            {
                ModelState.AddModelError("DataEntryDto.KTPFile", "The Image file is Required");
            }

            if (!ModelState.IsValid)
            {
                errorMessage = "Please provide all required fields";
                return;
            }

            #region Save Image KTP

            string newFileNameKTP = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            newFileNameKTP += Path.GetExtension(DataEntryDto.KTPFile!.FileName);

            string imageFullPathKTP = environment.WebRootPath + "/img/storage/" + newFileNameKTP;
            using (var stream = System.IO.File.Create(imageFullPathKTP))
            {
                DataEntryDto.KTPFile.CopyTo(stream);
            }

            #endregion

            #region Save Image NPWP

            string newFileNameNPWP = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            newFileNameNPWP += Path.GetExtension(DataEntryDto.NPWPFile!.FileName);

            string imageFullPathNPWP = environment.WebRootPath + "/img/storage/" + newFileNameNPWP;
            using (var stream = System.IO.File.Create(imageFullPathNPWP))
            {
                DataEntryDto.NPWPFile.CopyTo(stream);
            }

            #endregion

            #region Save Image SlipGaji

            string newFileNameSlipGaji = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            newFileNameSlipGaji += Path.GetExtension(DataEntryDto.NPWPFile!.FileName);

            string imageFullPathSlipGaji = environment.WebRootPath + "/img/storage/" + newFileNameSlipGaji;
            using (var stream = System.IO.File.Create(imageFullPathSlipGaji))
            {
                DataEntryDto.SlipGajiFile.CopyTo(stream);
            }

            #endregion

            #region Save Data Entry

            WebApplication1.Models.DataEntry dataEntry = new WebApplication1.Models.DataEntry()
            {
                Nama = DataEntryDto.Nama,
                NIK = DataEntryDto.NIK,
                TempatLahir = DataEntryDto.TempatLahir,
                TanggalLahir = DataEntryDto.TanggalLahir ?? DateTime.MinValue,
                JenisKelamin = DataEntryDto.JenisKelamin,
                AlamatLengkap = DataEntryDto.AlamatLengkap,
                Kelurahan = DataEntryDto.Kelurahan,
                Kabupaten = DataEntryDto.Kabupaten,
                KodePos = DataEntryDto.KodePos,
                NoRekeningTabungan = DataEntryDto.NoRekeningTabungan,
                KTPFileName = newFileNameKTP,
                Kecamatan = DataEntryDto.Kecamatan,
                Provinsi = DataEntryDto.Provinsi,
                NoHP = DataEntryDto.NoHP,
                AlamatEmail = DataEntryDto.AlamatEmail,
                JumlahPenghasilan = DataEntryDto.JumlahPenghasilan,
                JumlahPermohonan = DataEntryDto.JumlahPermohonan,
                MaksimalPermohonan = DataEntryDto.MaksimalPermohonan,
                StatusPerkawinan = DataEntryDto.StatusPerkawinan,
                NPWPFileName = newFileNameNPWP,
                SlipGajiFileName = newFileNameSlipGaji,
                JumlahPenghasilanLainnya = DataEntryDto.JumlahPenghasilanLainnya,
                JangkaWaktu = DataEntryDto.JangkaWaktu,
                TujuanPembiayaan = DataEntryDto.TujuanPembiayaan,
                NamaInstansi = DataEntryDto.NamaInstansi,
                Golongan = DataEntryDto.Golongan,
                MasaKerja = DataEntryDto.MasaKerja ?? DateTime.MinValue,
                AlamatKantor = DataEntryDto.AlamatKantor,
                NoInstansi = DataEntryDto.NoInstansi,
                NIP = DataEntryDto.NIP,
                NamaAtasan = DataEntryDto.NamaAtasan,
                TotalAngsuran = DataEntryDto.TotalAngsuran,
                Cabang = DataEntryDto.Cabang,
                Capem = DataEntryDto.Capem,
                JangkaWaktuPengajuan = DataEntryDto.JangkaWaktuPengajuan
            };

            dataEntry.DokumenChecklists = new List<DokumenChecklist>
            {
                new DokumenChecklist { Position = 1, DokumenName = "Karpeg", DataEntryId = dataEntry.Id },
                new DokumenChecklist { Position = 2, DokumenName = "Taspen", DataEntryId = dataEntry.Id },
                new DokumenChecklist { Position = 3, DokumenName = "SK 80%", DataEntryId = dataEntry.Id },
                new DokumenChecklist { Position = 4, DokumenName = "SK 100%", DataEntryId = dataEntry.Id },
                new DokumenChecklist { Position = 5, DokumenName = "SK Terakhir", DataEntryId = dataEntry.Id }
            };

            context.DataEntries.Add(dataEntry);
            context.SaveChanges();

            #endregion

            #region Clear Form

            DataEntryDto.Nama = "";
            DataEntryDto.NIK = "";
            DataEntryDto.TempatLahir = "";
            DataEntryDto.TanggalLahir = null;
            DataEntryDto.JenisKelamin = "";
            DataEntryDto.AlamatLengkap = "";
            DataEntryDto.Kelurahan = "";
            DataEntryDto.Kabupaten = "";
            DataEntryDto.KodePos = "";
            DataEntryDto.NoRekeningTabungan = "";
            DataEntryDto.KTPFile = null;
            DataEntryDto.Kecamatan = "";
            DataEntryDto.Provinsi = "";
            DataEntryDto.NoHP = "";
            DataEntryDto.AlamatEmail = "";
            DataEntryDto.AlamatEmail = "";
            DataEntryDto.JumlahPenghasilan = 0;
            DataEntryDto.JumlahPermohonan = 0;
            DataEntryDto.MaksimalPermohonan = 0;
            DataEntryDto.StatusPerkawinan = "";
            DataEntryDto.NPWPFile = null;
            DataEntryDto.SlipGajiFile = null;
            DataEntryDto.JumlahPenghasilanLainnya = 0;
            DataEntryDto.JangkaWaktu = 0;
            DataEntryDto.TujuanPembiayaan = "";
            DataEntryDto.NamaInstansi = "";
            DataEntryDto.Golongan = "";
            DataEntryDto.MasaKerja = null;
            DataEntryDto.AlamatKantor = "";
            DataEntryDto.NoInstansi = "";
            DataEntryDto.NIP = "";
            DataEntryDto.NamaAtasan = "";
            DataEntryDto.TotalAngsuran = 0;
            DataEntryDto.Cabang = "";
            DataEntryDto.Capem = "";
            DataEntryDto.JangkaWaktuPengajuan = 0;

            ModelState.Clear();
            successMessage = "Data Entry created successfully";
            Response.Redirect("/DataEntry/Index");

            #endregion
        }
    }
}
