Imports System
Imports System.IO

Module Program



    'Our Name Variable'
    Dim name As String

    'Our Price Variables'
    Dim priceAlpha As Integer
    Dim priceBeta As Integer
    Dim priceGamma As Integer

    'Our Sales Variables'
    Dim salesAlpha As Integer
    Dim salesBeta As Integer
    Dim salesGamma As Integer

    'Our Commission Variable, aka the end result'
    Dim commission As Integer

    'Our way to break out of the loop'
    Dim breaker As Boolean = False
    Dim breaker_two As Boolean = False
    Dim breaker_three As Boolean = False

    'Our percent variable'
    Dim percent As Integer

    'Main Loop For Our Program
    Sub Main(args As String())
        Console.WriteLine("Welcome To Our Calculate Commissions Application")


        'Our Loop to satisfy that our person is in the database'
        While breaker = False
            EnterName()
            CheckName(name)
        End While

        'Our commission rate for that person
        FindPercent(name)

        'Our Prices for our Products
        PriceSetting()

        'Our Sales for that person
        Sales(name)

        'Debugging Logs to make sure everything is coming out the right way
        Console.WriteLine("Price Of Alpha: " + CStr(priceAlpha))
        Console.WriteLine("Price of Beta: " + CStr(priceBeta))
        Console.WriteLine("Price of Gamma: " + CStr(priceGamma))
        Console.WriteLine("----------------------")
        Console.WriteLine("Sales of Alpha: " + CStr(salesAlpha))
        Console.WriteLine("Sales of Beta: " + CStr(salesBeta))
        Console.WriteLine("Sales of Gamma: " + CStr(salesGamma))

        'Our calculation for their commission'
        MagicMath()



    End Sub

    'This Method will allow you to input a name that you are looking for
    Sub EnterName()
        Console.WriteLine("====================")
        Console.WriteLine("Please Keep in mind that this application is case-sensitive")
        Console.WriteLine("Please Enter an Employee's Name: ")

        name = Console.ReadLine()
    End Sub

    'This Method will check if the name that you entered is in the file for our names'
    Sub CheckName(e_name As String)
        Dim filename As StreamReader
        Dim strInput As String
        filename = File.OpenText("C:\Users\CJ\Desktop\School\CS27\ConsoleAppMay10_2020\names.txt")
        strInput = filename.ReadToEnd()
        filename.Close()
        If (strInput.Contains(e_name)) Then
            breaker = True
            Console.WriteLine("Employee Found!")
        Else
            breaker = False
            Console.WriteLine("Employee Not Found, Please Try Again")
        End If

    End Sub

    'This method will give us the commission rate for our employee that we searched for'
    Sub FindPercent(e_name As String)
        Dim filename As StreamReader
        Dim strInput As String = ""

        'Our file location'
        filename = File.OpenText("C:\Users\CJ\Desktop\School\CS27\ConsoleAppMay10_2020\commissions.txt")

        'Loops Through our file to find the right value
        While breaker_two = False
            strInput = filename.ReadLine()
            If strInput.Contains(e_name) Then
                breaker_two = True
            End If
        End While
        filename.Close()
        'the integers are after a space in the file, so we'll grab anything after the space to attempt for an integer
        Dim found As Integer = strInput.IndexOf(" ")

        percent = CInt(strInput.Substring(found + 1))
        Console.WriteLine(name + "'s" + " commission rate is: " + CStr(percent) + "%")
    End Sub

    'This method will grab the price of the units from our files
    Sub PriceSetting()
        Dim filename As StreamReader
        Dim alpha As String = ""
        Dim beta As String = ""
        Dim gamma As String = ""
        filename = File.OpenText("C:\Users\CJ\Desktop\School\CS27\ConsoleAppMay10_2020\price-of-models.txt")
        alpha = filename.ReadLine
        beta = filename.ReadLine
        gamma = filename.ReadLine
        filename.Close()
        Dim alphaFound As Integer = alpha.IndexOf(" ")
        Dim betaFound As Integer = beta.IndexOf(" ")
        Dim gammaFound As Integer = gamma.IndexOf(" ")
        priceAlpha = CInt(alpha.Substring(alphaFound + 1))
        priceBeta = CInt(beta.Substring(betaFound + 1))
        priceGamma = CInt(gamma.Substring(gammaFound + 1))
    End Sub

    'grabs the sales of the last quarter from our file 
    Sub Sales(a As String)
        Dim filename As StreamReader
        Dim strInput As String = ""
        filename = File.OpenText("C:\Users\CJ\Desktop\School\CS27\ConsoleAppMay10_2020\sales-in-last-quarter.txt")

        While breaker_three = False
            strInput = filename.ReadLine()
            If strInput.Contains(a) Then
                breaker_three = True
            End If
        End While
        filename.Close()

        'This section deals with cutting up our string into different pieces to get the information that we want out of it
        Dim all As String = strInput.Substring(strInput.IndexOf(" ") + 1)
        Dim alpha As String = all.Substring(0, all.IndexOf(" "))
        Dim lastOnes As String = all.Substring(all.IndexOf(" ") + 1)
        Dim beta As String = lastOnes.Substring(0, lastOnes.IndexOf(" "))
        Dim gamma As String = lastOnes.Substring(lastOnes.IndexOf(" ") + 1)
        salesAlpha = CInt(alpha)
        salesBeta = CInt(beta)
        salesGamma = CInt(gamma)

    End Sub

    Sub MagicMath()
        commission = ((priceAlpha * salesAlpha) + (priceBeta * salesBeta) + (priceGamma * salesGamma)) * (percent / 100.0)
        Console.WriteLine(name + "'s commission is: $" + CStr(commission))
    End Sub

End Module
