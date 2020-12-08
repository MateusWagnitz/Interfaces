#region Teoria
// Interfaces
//Interface é um tipo que define um conjunto de operações que uma
//classe (ou struct) deve implementar
//A interface estabelece um contrato
//que a classe (ou struct) deve
//cumprir.
//Pra quê interfaces?
//• Para criar sistemas com baixo acoplamento e flexíveis.
//interface IShape
//{
//    double Area();
//    double Perimeter();
//}


//______________________________________________________________________
//Inversão de controle, Injeção de
//dependência

//Acoplamento forte
//• A classe RentalService conhece a dependência concreta
//• Se a classe concreta mudar, é preciso mudar a classe RentalService

//class RentalService
//{
//    (...)
//private BrazilTaxService _brazilTaxService = new BrazilTaxService();


//______________________________________________________________________
//• Acoplamento fraco
//• A classe RentalService não conhece a dependência concreta
//• Se a classe concreta mudar, a classe RentalService não muda nada

//class RentalService
//{
//    (...)
//private ITaxService _taxService;


//______________________________________________________________________
//Inversão de controle
//• Inversão de controle
//Padrão de desenvolvimento que consiste em retirar da classe a
//responsabilidade de instanciar suas dependências.
//• Injeção de dependência
//É uma forma de realizar a inversão de controle: um componente externo
//instancia a dependência, que é então injetada no objeto "pai". Pode ser
//implementada de várias formas:
//• Construtor
//• Objeto de instanciação (builder / factory)
//• Container / framework

//______________________________________________________________________
//Herdar vs.cumprir contrato

//______________________________________________________________________
//Aspectos em comum entre herança e interfaces

//• Relação é-um
//• Generalização/especialização
//• Polimorfismo

//Diferença fundamental
//• Herança => reuso
//• Interface => contrato a ser cumprido

//____________________________________________
//Herança múltipla e o problema do diamante
//A herança múltipla pode gerar o
//problema do diamante: uma
//ambiguidade causada pela
//existência do mesmo método em
//mais de uma superclasse.
//Herança múltipla não é
//permitida na maioria das
//linguagens!


//Porém, uma classe (ou struct) pode
//implementar mais de uma interface

//ATENÇÃO :
//Isso NÃO é herança múltipla,
//pois NÃO HÁ REUSO na relação
//entre ComboDevice e as
//interfaces Scanner e Printer.
//ComboDevide não herda, mas
//sim implementa as interfaces
//(cumpre o contrato).


//____________________________________________
//Interface Comparable
//public interface IComparable
//{
//    int CompareTo(object other);
//}



#endregion



using Interfaces.Entities;
using Interfaces.Services;
using System;
using System.Globalization;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Enunciado
            // Problema exemplo
            //Uma locadora brasileira de carros cobra um valor por hora para locações de até
            //12 horas.Porém, se a duração da locação ultrapassar 12 horas, a locação será
            //cobrada com base em um valor diário. Além do valor da locação, é acrescido no
            //preço o valor do imposto conforme regras do país que, no caso do Brasil, é 20 %
            //para valores até 100.00, ou 15 % para valores acima de 100.00.Fazer um
            //programa que lê os dados da locação(modelo do carro, instante inicial e final da
            //locação), bem como o valor por hora e o valor diário de locação. O programa
            //deve então gerar a nota de pagamento(contendo valor da locação, valor do
            // imposto e valor total do pagamento) e informar os dados na tela. Veja os
            //exemplos.

            //            Enter rental data
            //Car model: Civic
            //Pickup(dd / MM / yyyy hh: mm): 25 / 06 / 2018 10:30
            //Return(dd / MM / yyyy hh: mm): 25 / 06 / 2018 14:40
            //Enter price per hour: 10.00
            //Enter price per day: 130.00
            //INVOICE:
            //            Basic payment: 50.00
            //Tax: 10.00
            //Total payment: 60.00

            //Calculations:
            //Duration = (25 / 06 / 2018 14:40) -(25 / 06 / 2018 10:30) = 4:10 = 5 hours
            //Basic payment = 5 * 10 = 50
            //Tax = 50 * 20 % = 50 * 0.2 = 10

            #endregion

            #region Solução com interface
            Console.WriteLine("Enter rental data");
            Console.Write("Car model: ");
            string model = Console.ReadLine();
            Console.Write("Pickup (dd/MM/yyyy HH:mm): ");
            DateTime start = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            Console.Write("Return (dd/MM/yyyy HH:mm): ");
            DateTime finish = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            Console.Write("Enter price per hour: ");
            double hour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter price per day: ");
            double day = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            CarRental carRental = new CarRental(start, finish, new Vehicle(model));

            RentalService rentalService = new RentalService(hour, day, new BrazilTaxService());

            rentalService.ProcessInvoice(carRental);

            Console.WriteLine("INVOICE:");
            Console.WriteLine(carRental.Invoice);
            #endregion

        }
    }
}
