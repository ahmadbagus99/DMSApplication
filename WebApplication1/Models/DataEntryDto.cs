using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class DataEntryDto
    {
        [Required, MaxLength(100)]
        public string Nama { get; set; } = "";
        public string TempatLahir { get; set; } = "";

        [Required, MaxLength(10)]
        public string JenisKelamin { get; set; } = "";

        [Required]
        public string Kelurahan { get; set; } = "";

        [Required]
        public string Kecamatan { get; set; } = "";

        [Required]
        public string Kabupaten { get; set; } = "";

        [Required, MaxLength(10)]
        public string KodePos { get; set; } = "";

        [Required, MaxLength(13)]
        public string NoHP { get; set; } = "";

        public IFormFile? KTPFile { get; set; }

        [Required]
        public string NIK { get; set; } = "";

        [Required]
        public DateTime? TanggalLahir { get; set; }

        [Required]
        public string AlamatLengkap { get; set; } = "";

        [Required]
        public string Provinsi { get; set; } = "";

        [Required]
        public string NoRekeningTabungan { get; set; } = "";

        [Required]
        public string AlamatEmail { get; set; } = "";

        [Required]
        public decimal JumlahPenghasilan { get; set; }

        [Required]
        public decimal JumlahPermohonan { get; set; }

        [Required]
        public decimal MaksimalPermohonan { get; set; }

        [Required]
        public string StatusPerkawinan { get; set; } = "";

        [Required]
        public decimal JumlahPenghasilanLainnya { get; set; }

        [Required]
        public int JangkaWaktu { get; set; }

        [Required]
        public string TujuanPembiayaan { get; set; } = "";

        public IFormFile? NPWPFile { get; set; }

        public IFormFile? SlipGajiFile { get; set; }

        [Required]
        public string NamaInstansi { get; set; } = "";

        [Required]
        public string NoInstansi { get; set; } = "";

        [Required]
        public string Golongan { get; set; } = "";

        [Required]
        public string NIP { get; set; } = "";

        [Required]
        public DateTime? MasaKerja { get; set; }

        [Required]
        public string NamaAtasan { get; set; } = "";

        [Required]
        public string AlamatKantor { get; set; } = "";

        [Required]
        public decimal TotalAngsuran { get; set; }

        [Required]
        public string Cabang { get; set; } = "";

        [Required]
        public int JangkaWaktuPengajuan { get; set; }

        [Required]
        public string Capem { get; set; } = "";
        public List<DokumenChecklist>? DokumenChecklists { get; set; }
    }
}
