using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            ComputerFacade computer = new(new(), new(), new());

            computer.start();
        }
    }

    public struct CPU
    {
        public void Freeze() {
            Console.WriteLine("CPU Freezed");
        }
        public void Jump(long position) {
            Console.WriteLine($"CPU Jumped To position: {position}"); 
        }
        public void Excute() {
            Console.WriteLine("CPU Excuted");
        }
    }

    public struct HardDrive
    {
        public string Read(long lba, int size) {
            Console.WriteLine($"HardDrive Read lba: {lba} with size: {size}");
            return ""; }

    }

    public struct Memory
    {
        public void Load(long position, string data) {
            Console.WriteLine($"Memory Loaded position: {position}, and the data is: {data}");
        }
    }

    public class ComputerFacade
    {
        CPU _CPU;
        Memory _memory;
        HardDrive _hardDrive;
        public ComputerFacade(CPU cpu, Memory memory, HardDrive hardDrive)
        {
            _CPU = cpu;
            _memory = memory;
            _hardDrive = hardDrive;
        }
        public void start()
        {
            _CPU.Freeze();
            _memory.Load(15, "hjk");
            _hardDrive.Read(51, 512);
            _CPU.Jump(50);
            _CPU.Excute();
        }
    }
}
