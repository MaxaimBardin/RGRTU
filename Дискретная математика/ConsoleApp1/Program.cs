using System.Data.Common;

public static class Program
{
    private static Matrix _matIncidents = new Matrix(7,14);
    
    private static Matrix _matSmegnost = new Matrix(7,7);

    public static void Main(string[] args)
    {
        _matIncidents = CreateMatrixIncedent();

        _matSmegnost = CreateMatrixSmegnost(_matIncidents);
        

        Console.WriteLine(_matIncidents + "\n\n\n\n\n" + _matSmegnost);
    }

    private static Matrix CreateMatrixSmegnost(Matrix matInc)
    {
        var matSmg = new Matrix(7, 7);



        for (var x = 0; x < 14; x++)
        {
            int? value1 = null;
            int? value2 = null;

            for (var y = 0; y < 7; y++)
            {
                if (matInc.Get(x, y) == 1 || matInc.Get(x, y) == -1)
                {


                    if (value1 == null)
                    {
                        value1 = y;
                    }
                    else if (value2 == null)
                    {
                        value2 = y;
                    }

                    if (value1 != null && value2 != null)
                    {
                        matSmg.Set(value1.Value, value2.Value, 1);
                        matSmg.Set(value2.Value, value1.Value, 1);
                        if (matInc.Get(x,value2.Value) == -1)
                        {
                            matSmg.Set(value1.Value, value2.Value, 0);
                        }
                        if (matInc.Get(x, value1.Value) == -1)
                        {
                            matSmg.Set(value2.Value, value1.Value, 0);
                        }
                        break;
                    }
                    
                }
            }

            if (value2 == null && value1 != 0)
            {
                matSmg.Set(value1.Value, value1.Value, 1);
            }
        }
        return matSmg;
    }

    public class Matrix
    {
        private float[,] _matrixData;
        public Matrix(int row, int column)
        {
            _matrixData = new float[row, column];
        }

        public Matrix(float[,] mat)
        {
            _matrixData = mat;
        }

        public Matrix Set(int row, int column, float value)
        {
            _matrixData[column, row] = value;
            return this;
        }

        public float Get(int row, int column)
        {
            return _matrixData[column, row];
        }

        public override string ToString()
        {
            string result = string.Empty;

            for (var x = 0; x < _matrixData.GetLength(0); x++)
            {
                for (var y = 0; y < _matrixData.GetLength(1); y++)
                {
                    result += _matrixData[x,y] + ", ";
                }
                result+= "\n";
            }
            return result;
        }
    }
    
    private static Matrix CreateMatrixIncedent()
    {
        var mat = new Matrix(new float[,]
        {
            { 0,1,0,0,0,0,1,0,0,0,0,0,0,1},
            { -1,0,1,0,0,1,0,0,0,0,0,1,0,0},
            { 1,0,0,1,1,0,0,0,0,0,0,0,1,0},
            { 0,0,0,0,0,0,0,0,0,1,1,0,1,1},
            { 0,1,0,0,0,0,0,0,1,0,0,1,0,0},
            { 0,0,0,0,1,0,1,1,0,0,1,0,0,0},
            { 0,0,0,1,0,1,0,1,1,1,0,0,0,0}
        });
        return mat;

        
        

            /*{ 0,0,0,0,0,0,0},
              { 0,0,0,0,0,0,0},
              { 0,1,0,0,0,0,0},
              { 0,0,0,0,0,0,0},
              { 0,0,0,0,0,0,0},
              { 0,0,0,0,0,0,0},
              { 0,0,0,0,0,0,0},*/

        
    }

}