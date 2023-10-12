//?Alexis Suarez TP-1.0

using EnumAsteroidSize;
using EnumTypeMaterial;

namespace TP_1punto1
{
    class Program
    {
        public static void Main(){
            //Listas donde se alojaran los resultados finales
            List<int> collectedIron = new List<int>();
            List<int> collectedGold = new List<int>();
            List<int> collectedPlatinum = new List<int>();
            List<int> collectedMisellaneous = new List<int>();
            bool proceed = true;

            //Ciclo para consultar si seguir el programa o detenerlo
            while(proceed){
                int a = 0; //-> Valroes para autoincrementar y poder iterar de manera individual
                int b = 1;
                int c = 2;
                int d = 3;
                Random aleatorie = new Random();
                int systemNumber = aleatorie.Next(5000, 15050); // Numero aleatorio que se concatenara con el nombre del sistema dependiendo su valor
                int asteroidInTheSystem = aleatorie.Next(5000, 10001);
                int asteroidNumberCollected = aleatorie.Next(1, 12);
                int remainingNumber = asteroidInTheSystem - asteroidNumberCollected;

                int pequeño = (int)AsteroidSize.Pequenio;
                int mediano = (int)AsteroidSize.Mediano;
                int grande = (int)AsteroidSize.Grande;
                int cataclismico = (int)AsteroidSize.Cataclismico;
                int[] arraySize = { pequeño, mediano, grande, cataclismico };

                int[] totalObjectCollected = RunProgram(systemNumber,asteroidInTheSystem,asteroidNumberCollected,remainingNumber,arraySize);
                
                //Extraemos los valores recolectados y los alojamos correspondientemente en su lista
                for(int i = 0; i < totalObjectCollected.Length; i+=4){
                    if(i <= a){

                        collectedIron.Add(totalObjectCollected[a]);
                        collectedGold.Add(totalObjectCollected[b]);
                        collectedPlatinum.Add(totalObjectCollected[c]);
                        collectedMisellaneous.Add(totalObjectCollected[d]);

                        a += 4;
                        b += 4;
                        d += 4;
                        c += 4;
                    }else{Console.WriteLine("End");}
                };

                Console.WriteLine("You want to change systems?\nYes = Y or No = N");
                string response = Console.ReadLine().ToString();

                if(response.ToLower() != "y"){
                    proceed = false; //Paramos el ciclo
                    int totalAmount = collectedIron.Sum() + collectedGold.Sum() + collectedPlatinum.Sum() + collectedMisellaneous.Sum();
                    Console.WriteLine($"Hierro total: {collectedIron.Sum()} KG\nOro total: {collectedGold.Sum()} KG\nPlatino total: {collectedPlatinum.Sum()} KG\nMiscelaneo total: {collectedMisellaneous.Sum()} KG\nPor un total de {totalAmount} KG de carga");
                };
            };

        }


        //? Funcion del profesor

        static int[] GetRandomComposition(AsteroidSize asteroidType){
            int numberOfSize = Enum.GetNames(typeof(AsteroidSize)).Length;
            //el array composicion va a ser igual a la cantidad de posiciones de nuestro enum
            //composicion = [] -> composicion.append(cantidadDeTamaños); -> composicion = [1,2,3,4];
            int[] composition = new int[numberOfSize];
            int quantityOfMaterials = Enum.GetNames(typeof(TypeMaterial)).Length;
            int maximumMinerals = (int)asteroidType;

            Random random = new Random();

            for (int i = 0; i < quantityOfMaterials; i++)
            {
                //ej: mineralesMax = 5000; -> generamos un random entre 0 y 5000 (ej: 3000)
                //ahora minerales sera = 3000; entonces despues a ese max (5000) le restamos los minerales (3000) -> 5000 - 3000;
                // ponemos esos 3000 en el array, y ahora el maximo sera de 2000, se generara otro random (ej:1500)
                //y se le restara nuevamente al max que en este caso es ahora 2000 -> (2000 - 1500)
                //minerales sera de 1500, se guarda en el array y ahora el max actual sera tan solo de 500
                //y al final asignamos el resto a la ultima posicion;
                int minerals = random.Next(0, maximumMinerals);
                maximumMinerals -= minerals;
                composition[i] = minerals;

                if (i == quantityOfMaterials)
                {
                    composition[i] += maximumMinerals;
                }

            }

            return composition;

        }

        //Recibe el peso del asteroide y lo descompone en los 4 valores de materiales.
        static int[] MaterialSeparator(int asteroidWeight){
            int[] weightOfEachMaterial = GetRandomComposition((AsteroidSize)asteroidWeight);
            int lastValueMaterial = ((int)asteroidWeight - weightOfEachMaterial.Sum()) + weightOfEachMaterial[^1];
            Console.WriteLine($"Hierro ->{weightOfEachMaterial[0]}");
            Console.WriteLine($"Oro ->{weightOfEachMaterial[1]}");
            Console.WriteLine($"Platino ->{weightOfEachMaterial[2]}");
            Console.WriteLine($"Miscelaneo ->{lastValueMaterial}");
            int[] arrayOfMaterials = { weightOfEachMaterial[0], weightOfEachMaterial[1], weightOfEachMaterial[2], lastValueMaterial };
            return arrayOfMaterials;
        }


        //Recibimos la lista con los pesos de cada asteroide y lo mandamos a separar, para que cada asteroide sea descompuesto y extraido los materiales.
        static int[] DescomposeAsteroid(int[] asteroidSize){
            List<int> collectedMaterials = new List<int>();
            
            int len = 0;
            for (int i = 0; i < asteroidSize.Length; i++)
            {
                //Agarramos el asteroide y extraemos sus materiales. Los valores de los materiales quedaran todos juntos en una sola lista posteriormente
                int[] materials = MaterialSeparator(asteroidSize[i]); 

                if (i == len) //Si i es igual a len significa que no hay mas asteroides para procesar, por esto, comenzamos a guardar los materiales.
                {
                    foreach (int m in materials)
                    {
                        collectedMaterials.Add(m);
                    }

                }
                len++;
            }

            int[] newCollectedMaterials = collectedMaterials.ToArray();
            return newCollectedMaterials;
        }


        //Le pasamos el numero de asteroides atrapados que seran las veces que tendra que calcular. Y la lista de pesos para que aleatoriamente escoja los pesos
        //en base a la cantidad que atrapamos.
        static int[] CalculateWeights( int asteroidNumberCollected,int[] arraySize){
            int stop = 0;
            Random aleatorie = new Random();
            List<int> elements = new List<int>();

            while (asteroidNumberCollected > stop)
            {
                int weightIterator = aleatorie.Next(0, Enum.GetValues(typeof(AsteroidSize)).Length);
                elements.Add(arraySize[weightIterator]);
                stop ++;
            }
            
            int[] sizeFound = elements.ToArray();
            return sizeFound;
            
        }


        static void CreateSystem(int system, int asteroid, int collectedNumber, int remainingNumber){

            if (system >= 5000 && system <= 8000)
            {
                Console.WriteLine($"Bienvenido al sistema {system}B1");
                Console.WriteLine($"Actualmente se encuentran {asteroid} asteroides orvitando");
                Console.WriteLine($"Se atraparon los siguientes asteroides: {(collectedNumber)} y quedan {remainingNumber}");

            }
            else if (system > 8000 && system <= 10000)
            {
                Console.WriteLine($"Bienvenido al sistema {system}C10-P");
                Console.WriteLine($"Actualmente se encuentran {asteroid} asteroides orvitando");
                Console.WriteLine($"Se atraparon los siguientes asteroides: {(collectedNumber)} y quedan {remainingNumber}");

            }
            else if (system > 10000 && system <= 15049)
            {
                Console.WriteLine($"Bienvenido al sistema {system}X99-A");
                Console.WriteLine($"Actualmente se encuentran {asteroid} asteroides orvitando");
                Console.WriteLine($"Se atraparon los siguientes asteroides: {(collectedNumber)} y quedan {remainingNumber}");

            }
            else
            {
                Console.WriteLine("System Not Found");
            }
        }        


        static int[] RunProgram(int systemNumber, int asteroidInTheSystem, int asteroidNumberCollected, int remainingNumber, int[] arraySize){
             
            CreateSystem(systemNumber, asteroidInTheSystem, asteroidNumberCollected, remainingNumber);
            int[] asteroidSize = CalculateWeights(asteroidNumberCollected, arraySize);
            foreach (int t in asteroidSize) {Console.WriteLine($"Tamaño del asteroide obtenido-> {t}");}
            int[] totalMaterialCollected = DescomposeAsteroid(asteroidSize);

            return totalMaterialCollected;
        }
    }
}
