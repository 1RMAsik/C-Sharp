class Credit_card{

    private string Username {set; get;}
    private double balance {set; get;}
    private double limit {set; get;}
    private bool blocked {set; get;}

    public Credit_card(string Username, double balance, double limit){
       this.Username = Username;
       this.balance = balance;
       this.limit = limit;

    }
    public void Add_balance(){
        double cash;
        Console.WriteLine("Введите сумму для зачисления: ");
        cash = double.Parse(Console.ReadLine());
        balance += cash;
        if(balance < 0){
        Console.WriteLine("Операция прошла успешно!");
        }
        else{
            red_dead_redempton();
            blocked = false;
        }
    }

     public void Purchase(){
        if (blocked == true){
            Console.WriteLine("Операция отменена, т.к. ваш баланс превысил лимит!");
        }
        else{
       double cash;
        Console.WriteLine("Введите сумму для покупки: ");
        cash = double.Parse(Console.ReadLine());
        balance -= cash;
        if(balance <= limit){
            out_limit(); 
            blocked = true;
           
            


        }
        else{
           
            Console.WriteLine($"Операция прошла успешно! Ваш баланс: {balance}");
           
        }
        
        
    }
     }

    static void err_color(){
    Console.ForegroundColor = ConsoleColor.Red; 
    

    }
    static void error(){
        Console.WriteLine("Операция проведена успешно, но вы теперь нищий :(");
    }
    static void rdr(){
        Console.WriteLine("Операция прошла успешно!");
        Console.WriteLine("Теперь вы снова можете оплачивать! :)");
    }
    static void suc_color(){
    Console.ForegroundColor = ConsoleColor.Green; 
    

    }
    static void res_color(){
        Console.ResetColor();
    }
    public delegate void Del();
    public event Del out_limit;
    public event Del red_dead_redempton;
    
    private static void Main(string[] args){
        
        Console.WriteLine("Введите ваше имя:");
        string Username = Console.ReadLine();
        double balance = 450;
        Console.WriteLine($"В качестве нового клиента, вам предоставляется бонус  в размере: {balance} TL");
        double limit = -100;
        Console.WriteLine($"Ваш лимит составляет: {limit}");
        Credit_card user_Nick = new Credit_card(Username, balance, limit);
        Console.WriteLine("-------------------МЕНЮ-------------------");
        Console.WriteLine("1 – просмотр состояния карты;");
        Console.WriteLine("2 – совершить покупку;");
        Console.WriteLine("3 – пополнить счёт;");
        Console.WriteLine("0 – выход. ");
        Console.WriteLine("------------------------------------------");
        Console.WriteLine("Для выбора действия нажмите соответствующую клавишу");
        user_Nick.out_limit+= err_color;
        user_Nick.out_limit+= error;
        
        user_Nick.red_dead_redempton += suc_color;
        user_Nick.red_dead_redempton += rdr;
        user_Nick.red_dead_redempton += res_color;
    while(true)
        {
         int n = int.Parse(Console.ReadLine());
            
            if(n == 1){ 
                Console.WriteLine($"Баланс вашего составляет: {user_Nick.balance} TL");
            }
           else if(n == 2){
                user_Nick.Purchase();
            }
            else if(n == 3){
                user_Nick.Add_balance();
            }
            else if(n == 0){
                Console.WriteLine("Приятного вам дня:");
            }
            else{ 
                Console.WriteLine("Что то пошло не так!");
            break;
            }
            
        }
        
    }

}
