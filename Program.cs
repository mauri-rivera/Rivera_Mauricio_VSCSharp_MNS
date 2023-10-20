
Humano pruebaHumano = new Humano("luchador_1", 30, 15, 45, 225);
Mago pruebaMago = new Mago("mago_1", 10, 20);
Ninja pruebaNinja = new Ninja("ninja_1", 45, 65, 90);
Samurai pruebaSamurai = new Samurai("samurai_1", 55, 25, 65);

Console.WriteLine("--------------------------------------------");
Console.WriteLine($"Salud del {pruebaHumano.Nombre} antes de recibir daño por el {pruebaMago.Nombre}: {pruebaHumano.Salud}");
Console.WriteLine("--------------------------------------------");
Console.WriteLine($"Salud del {pruebaMago.Nombre} antes de sanarse: {pruebaMago.Salud}");
Console.WriteLine("--------------------------------------------");
pruebaMago.Atacar(pruebaHumano);
Console.WriteLine($"Salud del {pruebaHumano.Nombre} después de recibir daño por el {pruebaMago.Nombre}: {pruebaHumano.Salud}");
Console.WriteLine("--------------------------------------------");
Console.WriteLine($"Salud del {pruebaMago.Nombre} después de atacar al {pruebaHumano.Nombre} daño: {pruebaMago.Salud}");
Console.WriteLine("--------------------------------------------");
pruebaMago.Sanar(pruebaHumano);
Console.WriteLine($"Salud del {pruebaHumano.Nombre} después de ser sanado por el {pruebaMago.Nombre}: {pruebaHumano.Salud}");
Console.WriteLine("--------------------------------------------");
Console.WriteLine($"Salud del {pruebaHumano.Nombre} antes de recibir daño por el {pruebaNinja.Nombre}: {pruebaHumano.Salud}");
Console.WriteLine("--------------------------------------------");
pruebaNinja.Atacar(pruebaHumano);
Console.WriteLine("--------------------------------------------");
Console.WriteLine($"Salud del {pruebaHumano.Nombre} después de recibir daño por el {pruebaNinja.Nombre}: {pruebaHumano.Salud}");
Console.WriteLine("--------------------------------------------");
pruebaNinja.Robar(pruebaHumano);
Console.WriteLine($"Salud del {pruebaHumano.Nombre} después de robo por el {pruebaNinja.Nombre}: {pruebaHumano.Salud}");
Console.WriteLine("--------------------------------------------");
Console.WriteLine($"Salud del {pruebaHumano.Nombre} antes de recibir daño por el {pruebaSamurai.Nombre}: {pruebaHumano.Salud}");
Console.WriteLine("--------------------------------------------");
pruebaSamurai.Atacar(pruebaHumano);
Console.WriteLine("--------------------------------------------");
Console.WriteLine($"Salud del {pruebaSamurai.Nombre}: {pruebaSamurai.Salud}");
Console.WriteLine("--------------------------------------------");
pruebaSamurai.Meditar();
Console.WriteLine("--------------------------------------------");


class Humano
{
    public string Nombre { get; set; }
    public int Fuerza { get; set; }
    public int Inteligencia { get; set; }
    public int Destreza { get; set; }
    public int Salud { get; set; }

    public Humano(string nombre, int f, int intel, int des, int hp)
    {
        Nombre = nombre;
        Fuerza = f;
        Inteligencia = intel;
        Destreza = des;
        Salud = hp;
    }

    public virtual void Atacar(Humano target)
    {
        int daño = Fuerza * 3;
        target.Salud -= daño;
        Console.WriteLine($"{Nombre} atacó a {target.Nombre} para hacer {daño} de daño!");
        Console.WriteLine("--------------------------------------------");
    }
}

class Mago : Humano
{
    public Mago(string nombre, int f, int des) : base(nombre, f, 25, des, 50) { }

    public override void Atacar(Humano target)
    {
        int daño = Inteligencia * 3;
        target.Salud -= daño;
        Salud += daño;
    }

    public void Sanar(Humano target)
    {
        int hp = Inteligencia * 3;
        target.Salud += hp;
    }
}

class Ninja : Humano
{
    public Ninja(string nombre, int f, int intel, int hp) : base(nombre, f, intel, 75, hp) { }

    public override void Atacar(Humano target)
    {
        Random probabilidad = new Random();
        int porcentaje = probabilidad.Next(0, 100);
        int dañoAdicional;

        Console.WriteLine($"Probabilidad de daño adicional del {Nombre}: {porcentaje}");
        Console.WriteLine("--------------------------------------------");

        if (porcentaje > 20)
        {
            Console.WriteLine($"Daño del {Nombre}: {Destreza}");
            target.Salud -= Destreza;
        }
        else
        {
            dañoAdicional = Destreza + 10;
            Console.WriteLine($"Daño del {Nombre}: {dañoAdicional}");
            target.Salud -= dañoAdicional;
        }
    }

    public void Robar(Humano target)
    {
        target.Salud -= 5;
        Salud += 5;
    }
}

class Samurai : Humano
{
    public Samurai(string nombre, int f, int intel, int des) : base(nombre, f, intel, des, 200) { }

    public override void Atacar(Humano target)
    { 
        if (target.Salud >= 50)
        {
            base.Atacar(target);
            if (target.Salud > 0)
            {
                Console.WriteLine($"Salud del {target.Nombre} después de recibir daño por el {Nombre}: {target.Salud}");
            }
            else
            {
                Console.WriteLine($"El {target.Nombre} está aniquilado por el {Nombre}");
            }
            
        }
        else
        {
            target.Salud = 0;
            Console.WriteLine($"El {target.Nombre} está aniquilado por el {Nombre}");
        }
    }

    public void Meditar()
    {
        if (Salud < 200)
        {
            Salud = 200;
            Console.WriteLine($"La salud del {Nombre} después de meditar (se recuperar al 100%): {Salud}");
        }
        else
        {
            Console.WriteLine($"La salud del {Nombre} está al 100%. No es necesario meditar");
        }
    }
}