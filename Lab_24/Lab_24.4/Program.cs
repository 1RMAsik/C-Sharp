using System;
using System.Threading;

class Player
{
    private int health;
    private bool isAlive;

    public Player(int health)
    {
        this.health = health;
        this.isAlive = true;
    }

    public int Health
    {
        get { return this.health; }
        set
        {
            this.health = value;
            if (this.health <= 0)
            {
                this.health = 0;
                this.isAlive = false;
            }
        }
    }

    public bool IsAlive
    {
        get { return this.isAlive; }
    }
}

class Program
{
    static Random rand = new Random();

    static void Main()
    {
        Player player = new Player(100);

        Thread attackThread = new Thread(() => Attack(player));
        Thread healThread = new Thread(() => Heal(player));

        attackThread.Start();
        healThread.Start();

        while (player.IsAlive)
        {
            Thread.Sleep(1000);
        }

        attackThread.Join();
        healThread.Join();

        Console.WriteLine("Вы погибли!");
    }

    static void Attack(Player player)
    {
        while (player.IsAlive)
        {
            int damage = rand.Next(20, 40);
            player.Health -= damage;
            Console.WriteLine("Вас атаковал Алексей Костенко. Нанесено урона: {0} Ваше здоровье: {1}", damage, player.Health);
            Thread.Sleep(2000);
        }
    }

    static void Heal(Player player)
    {
        while (player.IsAlive)
        {
            int heal = rand.Next(0, 11);
            player.Health += heal;
            Console.WriteLine("Восстановлено: {0}% hp. Ваше здоровье: {1}", heal, player.Health);
            Thread.Sleep(3000);
        }
    }
}