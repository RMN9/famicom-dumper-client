﻿namespace com.clusterrr.Famicom.Mappers
{
    class VRC2a : IMapper
    {
        public string Name
        {
            get { return "VRC2a"; }
        }

        public int Number
        {
            get { return 22; }
        }

        public string UnifName
        {
            get { return null; }
        }

        public int DefaultPrgSize
        {
            get { return 256 * 1024; }
        }

        public int DefaultChrSize
        {
            get { return 256 * 1024; }
        }

        public void DumpPrg(FamicomDumperConnection dumper, List<byte> data, int size)
        {
            int banks = size / 0x2000;
            
            dumper.WriteCpu(0x9001, 0); // disable swap mode
            for (int bank = 0; bank < banks; bank++)
            {
                Console.Write("Reading PRG bank #{0}... ", bank);
                dumper.WriteCpu(0x8000, (byte)bank); // PRG Select 0
                data.AddRange(dumper.ReadCpu(0x8000, 0x2000));
                Console.WriteLine("OK");
            }
        }

        public void DumpChr(FamicomDumperConnection dumper, List<byte> data, int size)
        {
            int banks = size / 0x400;
            
            for (int bank = 0; bank < banks; bank++)
            {
                Console.Write("Reading CHR bank #{0}... ", bank);
                dumper.WriteCpu(0xB000, (byte)((bank >> 1) & 0x0F)); // CHR Select 0 low
                dumper.WriteCpu(0xB002, (byte)(bank >> 5)); // CHR Select 0 high
                data.AddRange(dumper.ReadPpu(0x0000, 0x0400));
                Console.WriteLine("OK");
            }
        }

        public void EnablePrgRam(FamicomDumperConnection dumper)
        {
            Console.WriteLine("Warning: SRAM is not supported by this mapper");
        }
    }
}