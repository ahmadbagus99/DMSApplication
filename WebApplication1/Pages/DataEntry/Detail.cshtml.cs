using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Pages.DataEntry
{
    public class EditModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly ApplicationDbContext context;

        [BindProperty]
        public DataEntryDto DataEntryDto { get; set; } = new DataEntryDto();
        public WebApplication1.Models.DataEntry DataEntry { get; set; } = new WebApplication1.Models.DataEntry();

        public string errorMessage = "";
        public string successMessage = "";
        public EditModel(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }
        public void OnGet(int? id)
        {
            if (id == null)
            {
                Response.Redirect("/DataEntry/Index");
                return;
            }

            var dataEntry = context.DataEntries.Find(id);
            if (dataEntry == null)
            {
                Response.Redirect("/DataEntry/Index");
                return;
            }

            DataEntryDto.Nama = dataEntry.Nama;
            DataEntryDto.NIK = dataEntry.NIK;
            DataEntryDto.TempatLahir = dataEntry.TempatLahir;
            DataEntryDto.TanggalLahir = dataEntry.TanggalLahir;
            DataEntryDto.JenisKelamin = dataEntry.JenisKelamin;
            DataEntryDto.AlamatLengkap = dataEntry.AlamatLengkap;
            DataEntryDto.Kelurahan = dataEntry.Kelurahan;
            DataEntryDto.Kabupaten = dataEntry.Kabupaten;
            DataEntryDto.KodePos = dataEntry.KodePos;
            DataEntryDto.NoRekeningTabungan = dataEntry.NoRekeningTabungan;
            DataEntryDto.Kecamatan = dataEntry.Kecamatan;
            DataEntryDto.Provinsi = dataEntry.Provinsi;
            DataEntryDto.NoHP = dataEntry.NoHP;
            DataEntryDto.AlamatEmail = dataEntry.AlamatEmail;
            DataEntryDto.JumlahPenghasilan = dataEntry.JumlahPenghasilan;
            DataEntryDto.JumlahPermohonan = dataEntry.JumlahPermohonan;
            DataEntryDto.MaksimalPermohonan = dataEntry.MaksimalPermohonan;
            DataEntryDto.StatusPerkawinan = dataEntry.StatusPerkawinan;
            DataEntryDto.JumlahPenghasilanLainnya = dataEntry.JumlahPenghasilanLainnya;
            DataEntryDto.JangkaWaktu = dataEntry.JangkaWaktu;
            DataEntryDto.TujuanPembiayaan = dataEntry.TujuanPembiayaan;
            DataEntryDto.NamaInstansi = dataEntry.NamaInstansi;
            DataEntryDto.Golongan = dataEntry.Golongan;
            DataEntryDto.MasaKerja = dataEntry.MasaKerja;
            DataEntryDto.AlamatKantor = dataEntry.AlamatKantor;
            DataEntryDto.NoInstansi = dataEntry.NoInstansi;
            DataEntryDto.NIP = dataEntry.NIP;
            DataEntryDto.NamaAtasan = dataEntry.NamaAtasan;
            DataEntryDto.TotalAngsuran = dataEntry.TotalAngsuran;
            DataEntryDto.Cabang = dataEntry.Cabang;
            DataEntryDto.Capem = dataEntry.Capem;
            DataEntryDto.JangkaWaktuPengajuan = dataEntry.JangkaWaktuPengajuan;
            DataEntryDto.DokumenChecklists = dataEntry.DokumenChecklists;

            DataEntry = dataEntry;
        }

        public void OnPost(int? id)
        {
            if (id == null)
            {
                Response.Redirect("/DataEntry/Index");
                return;
            }

            if (!ModelState.IsValid)
            {
                errorMessage = "Please Provide all required fields";
                return;
            }

            var dataEntry = context.DataEntries.Find(id);
            if (dataEntry == null)
            {
                Response.Redirect("/DataEntry/Index");
                return;
            }

            #region update images KTP
            string newFileNameKTP = dataEntry.KTPFileName;
            if (DataEntryDto.KTPFile != null)
            {
                newFileNameKTP = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                newFileNameKTP += Path.GetExtension(DataEntryDto.KTPFile.FileName);

                string imageFullPath = environment.WebRootPath + "/img/storage/" + newFileNameKTP;
                using (var stream = System.IO.File.Create(imageFullPath))
                {
                    DataEntryDto.KTPFile.CopyTo(stream);
                }

                string oldImageFullPathKTP = environment.WebRootPath + "/img/storage/" + dataEntry.KTPFileName;
                System.IO.File.Delete(oldImageFullPathKTP);
            }
            #endregion

            #region update images NPWP
            string newFileNameNPWP = dataEntry.NPWPFileName;
            if (DataEntryDto.NPWPFile != null)
            {
                newFileNameNPWP = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                newFileNameNPWP += Path.GetExtension(DataEntryDto.NPWPFile.FileName);

                string imageFullPathNPWP = environment.WebRootPath + "/img/storage/" + newFileNameNPWP;
                using (var stream = System.IO.File.Create(imageFullPathNPWP))
                {
                    DataEntryDto.NPWPFile.CopyTo(stream);
                }

                string oldImageFullPathNPWP = environment.WebRootPath + "/img/storage/" + dataEntry.NPWPFileName;
                System.IO.File.Delete(oldImageFullPathNPWP);
            }
            #endregion

            #region update images Slip Gaji
            string newFileNameSlipGaji = dataEntry.SlipGajiFileName;
            if (DataEntryDto.SlipGajiFile != null)
            {
                newFileNameSlipGaji = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                newFileNameSlipGaji += Path.GetExtension(DataEntryDto.SlipGajiFile.FileName);

                string imageFullPathSlipGaji = environment.WebRootPath + "/img/storage/" + newFileNameSlipGaji;
                using (var stream = System.IO.File.Create(imageFullPathSlipGaji))
                {
                    DataEntryDto.SlipGajiFile.CopyTo(stream);
                }

                string oldImageFullPathSlipGaji = environment.WebRootPath + "/img/storage/" + dataEntry.SlipGajiFileName;
                System.IO.File.Delete(oldImageFullPathSlipGaji);
            }
            #endregion

            #region update data entries

            dataEntry.Nama = DataEntryDto.Nama;
            dataEntry.NIK = DataEntryDto.NIK;
            dataEntry.TempatLahir = DataEntryDto.TempatLahir;
            dataEntry.TanggalLahir = DataEntryDto.TanggalLahir ?? DateTime.MinValue;
            dataEntry.JenisKelamin = DataEntryDto.JenisKelamin;
            dataEntry.AlamatLengkap = DataEntryDto.AlamatLengkap;
            dataEntry.Kelurahan = DataEntryDto.Kelurahan;
            dataEntry.Kabupaten = DataEntryDto.Kabupaten;
            dataEntry.KodePos = DataEntryDto.KodePos;
            dataEntry.NoRekeningTabungan = DataEntryDto.NoRekeningTabungan;
            dataEntry.KTPFileName = newFileNameKTP;
            dataEntry.Kecamatan = DataEntryDto.Kecamatan;
            dataEntry.Provinsi = DataEntryDto.Provinsi;
            dataEntry.NoHP = DataEntryDto.NoHP;
            dataEntry.AlamatEmail = DataEntryDto.AlamatEmail;
            dataEntry.JumlahPenghasilan = DataEntryDto.JumlahPenghasilan;
            dataEntry.JumlahPermohonan = DataEntryDto.JumlahPermohonan;
            dataEntry.MaksimalPermohonan = DataEntryDto.MaksimalPermohonan;
            dataEntry.StatusPerkawinan = DataEntryDto.StatusPerkawinan;
            dataEntry.NPWPFileName = newFileNameNPWP;
            dataEntry.SlipGajiFileName = newFileNameSlipGaji;
            dataEntry.JumlahPenghasilanLainnya = DataEntryDto.JumlahPenghasilanLainnya;
            dataEntry.JangkaWaktu = DataEntryDto.JangkaWaktu;
            dataEntry.TujuanPembiayaan = DataEntryDto.TujuanPembiayaan;
            dataEntry.NamaInstansi = DataEntryDto.NamaInstansi;
            dataEntry.Golongan = DataEntryDto.Golongan;
            dataEntry.MasaKerja = DataEntryDto.MasaKerja ?? DateTime.MinValue;
            dataEntry.AlamatKantor = DataEntryDto.AlamatKantor;
            dataEntry.NoInstansi = DataEntryDto.NoInstansi;
            dataEntry.NIP = DataEntryDto.NIP;
            dataEntry.NamaAtasan = DataEntryDto.NamaAtasan;
            dataEntry.TotalAngsuran = DataEntryDto.TotalAngsuran;
            dataEntry.Cabang = DataEntryDto.Cabang;
            dataEntry.Capem = DataEntryDto.Capem;
            dataEntry.JangkaWaktuPengajuan = DataEntryDto.JangkaWaktuPengajuan;

            context.SaveChanges();

            #endregion

            DataEntry = dataEntry;
            successMessage = "Data Entries updated successfully";
            //Response.Redirect("/DataEntry/Index");
        }

        public IActionResult DownloadKTP(string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/storage", fileName);

            if (!System.IO.File.Exists(filePath))
                return NotFound();

            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/octet-stream", fileName);
        }

    }
}
