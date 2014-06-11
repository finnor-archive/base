import java.util.Scanner;

public class WhileCalc
{
    public static void main(String[] args)
    {
        Scanner scan = new Scanner(System.in);
        int inputValue, y, z = 1;
        System.out.print("Enter an integer between 1 and 10: ");
        inputValue = scan.nextInt();
        if( inputValue >= 1 && inputValue <= 10 );
        {
            y = 1;
            while(y <= inputValue)
            {
                z = z * y;
                y++;
            }
            
            System.out.println("Calculated value is " + z);
        }
    }
}
