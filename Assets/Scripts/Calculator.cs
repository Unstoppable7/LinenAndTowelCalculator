
using System;

public static class Calculator
{
    public static int[] ForNroHab(int hab, bool onlySheets = false)
    {
        int[] rsp = new int[9];
        int SK, SQ, DK, DQ, TGMP, Tp, PC, towelExtra;

        rsp[0] = SK = hab * 2;
        rsp[1] = SQ = hab * 4;
        rsp[2] = DK = hab;
        rsp[3] = DQ = SK;
        
        //Calculo de las toallas sobre hab que tienen 3 baños, 1/4 del total de las hab
        //tienen 3 baños
        towelExtra = (hab * 1 / 4) * 2;
        rsp[4] = rsp[5] = rsp[6] =TGMP = (hab * 4) + towelExtra;
        rsp[7] = Tp = (int)Math.Round(TGMP/2f);
        
        //3 Paquetes de pillows por hab
        rsp[8] = PC = hab * 3;

        return rsp;
    }

    private static int ForCountOfSK(int cant)
    {
        return (int)Math.Round(cant / 2f) - 1;
    }
    private static int ForCountOfSQ(int cant)
    {
        return (int)Math.Round(cant / 4f) - 1;
    }
    //ForCountOfDK return cant
    
    private static int ForCountOfDQ(int cant)
    {
        return ForCountOfSK(cant);
    }
    private static int ForCountOfTGMP(int cant)
    {
        return ForCountOfSQ(cant);
    }
    private static int ForCountOfTp(int cant)
    {
        return ForCountOfSK(cant);
    }
    private static int ForCountOfPC(int cant)
    {
        return (int)Math.Round(cant / 12f) - 1;
    }
}
