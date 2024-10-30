using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class DataEntry
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Nama { get; set; } = "";
        public string TempatLahir { get; set; } = "";

        [MaxLength(10)]
        public string JenisKelamin { get; set; } = "";

        public string Kecamatan { get; set; } = "";

        public string Kelurahan { get; set; } = "";

        public string Kabupaten { get; set; } = "";

        [MaxLength(10)]
        public string KodePos { get; set; } = "";

        [MaxLength(13)]
        public string NoHP { get; set; } = "";

        public string KTPFileName { get; set; } = "";

        public string NIK { get; set; } = "";

        public DateTime TanggalLahir { get; set; }

        public string AlamatLengkap { get; set; } = "";

        public string Provinsi { get; set; } = "";

        public string NoRekeningTabungan { get; set; } = "";

        public string AlamatEmail { get; set; } = "";

        public decimal JumlahPenghasilan { get; set; }

        public decimal JumlahPermohonan { get; set; }

        public decimal MaksimalPermohonan { get; set; }

        public string StatusPerkawinan { get; set; } = "";

        public decimal JumlahPenghasilanLainnya { get; set; }

        public int JangkaWaktu { get; set; }

        public string TujuanPembiayaan { get; set; } = "";

        public string NPWPFileName { get; set; } = "";

        public string SlipGajiFileName { get; set; } = "";

        public string NamaInstansi { get; set; } = "";

        public string NoInstansi { get; set; } = "";

        public string Golongan { get; set; } = "";

        public string NIP { get; set; } = "";

        public DateTime MasaKerja { get; set; }

        public string NamaAtasan { get; set; } = "";

        public string AlamatKantor { get; set; } = "";

        public decimal TotalAngsuran { get; set; }

        public string Cabang { get; set; } = "";

        public int JangkaWaktuPengajuan { get; set; }
        public string Capem { get; set; } = "";

        public List<DokumenChecklist>? DokumenChecklists { get; set; }
    }
}
