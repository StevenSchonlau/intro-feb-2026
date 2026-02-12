
public class Calculator
{
    public int Add(string numbers)
    {
        
        var number_substr = "";
        var total = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (Char.IsDigit(numbers[i]) || numbers[i] == '-')
            {
                number_substr += numbers[i];
            }
            else
            {
                if (number_substr.Length != 0) {
                    total += int.Parse(number_substr);
                }
                number_substr = "";
            }
        }
        if (number_substr.Length != 0)
        {
            total += int.Parse(number_substr);
        }
        return total;
        
        
        /* Prior to step 6
        if (numbers.Contains(','))
        {
            var sides = numbers.Split(',');
            var total = 0;
            foreach (var side in sides)
            {
                if (side.Contains("\n"))
                {

                    var inner = side.Split('\n');
                    foreach (var part in inner)
                    {
                        total += int.Parse(part);
                    }
                }
                else
                {

                    total += int.Parse(side);
                }
            }
            return total;
        }
        if (numbers.Length == 0)
        {
            return 0;
        }
        return int.Parse(numbers); 
        */
    }
}
