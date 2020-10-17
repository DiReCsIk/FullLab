using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLab
{
    public class Vector
    {
        private class VectorElem
        {
            public int index;
            public double data;
            public VectorElem next;
            public VectorElem(int index, double data)
            {
                this.index = index;
                this.data = data;
            }
            public VectorElem(int index, double data, VectorElem next)
            {
                this.index = index;
                this.data = data;
                this.next = next;
            }
        }
        private VectorElem currentElem;
        public int ListSize { get; set; }
        public Vector()
        {
            ListSize = 0;
            currentElem = null;
        }
        public Vector(int listSize)
        {
            if (listSize >= 0)
            {
                ListSize = listSize;
                currentElem = null;
            }
            else
            {
                throw new Exception("Вектор не может иметь отрицательный размер!");
            }
        }
        public Vector(Vector other)
        {
            ListSize = other.ListSize;
            VectorElem otherTemp = other.currentElem;
            while (otherTemp != null)
            {
                Add(otherTemp.index, otherTemp.data);
                otherTemp = otherTemp.next;
            }
        }
        private VectorElem FindElem(int index)
        {
            if (currentElem != null)
            {
                VectorElem otherVector = currentElem;
                while (otherVector != null)
                {
                    if (otherVector.index == index)
                    {
                        return otherVector;
                    }
                    if (otherVector.index > index)
                    {
                        return null;
                    }
                    otherVector = otherVector.next;
                }
            }
            return null;
        }
        private void Add(int index, double data)
        {
            if (currentElem == null)
            {
                currentElem = new VectorElem(index, data);
            }
            else
            {
                if (index > currentElem.index)
                {
                    VectorElem otherVector = currentElem;
                    while (otherVector.next != null)
                    {
                        if (otherVector.next.index >= index)
                        {
                            break;
                        }
                        otherVector = otherVector.next;
                    }
                    VectorElem newElem = new VectorElem(index, data);
                    if (otherVector.next != null)
                    {
                        newElem.next = otherVector.next;
                    }
                    otherVector.next = newElem;
                }
                else
                {
                    VectorElem newElem = currentElem;
                    currentElem.data = data;
                    currentElem.index = index;
                    currentElem.next = newElem;
                }
            }
        }
        private void ReplaceData(int index, double data)
        {
            VectorElem otherVector = currentElem;
            while (otherVector.index != index)
            {
                otherVector = otherVector.next;
            }
            otherVector.data = data;
        }
        public void AssignValueByIndex(int index, double data)
        {
            if (index > ListSize || index < 1)
            {
                throw new Exception("Переданный индекс некорректен!");
            }
            if (index == 0)
            {
                RemoveElemByIndex(index);
            }
            else if (FindElem(index) == null)
            {
                Add(index, data);
            }
            else
            {
                ReplaceData(index, data);
            }
        }
        private Vector Invert(Vector other)
        {
            VectorElem temp = other.currentElem;
            while (temp != null)
            {
                temp.data = -temp.data;
                temp = temp.next;
            }
            return other;
        }
        public void PrintVector()
        {
            VectorElem otherVector = currentElem;
            for (int i = 1; i < ListSize + 1; i++)
            {
                if (otherVector.index == i)
                {
                    Console.WriteLine("Номер пространства: " + i + " данные: " + otherVector.data);
                    otherVector = otherVector.next;
                }
                else
                {
                    Console.WriteLine("Номер пространства: " + i + " данные: " + 0);
                }
            }
        }
        public void InputElem()             //check one more time
        {
            int index = 0, data = 0;
            Console.Write("Введите индекс пространства: ");
            if (Int32.TryParse(Console.ReadLine(), out index))      //int oyt
            {
                if (index > ListSize || index < 0)
                {
                    throw new IndexOutOfRangeException("Переданный индекс выходит за допустимые рамки!");
                }
                Console.WriteLine("Введите данные в числовом формате: ");
                if (Int32.TryParse(Console.ReadLine(), out data))
                {
                    AssignValueByIndex(index, data);
                }
                else
                {
                    throw new Exception("Были введены некорректные данные!");
                }
            }
            else
            {
                throw new Exception("Был введен некорректный индекс!");
            }
        }
        private void RemoveElemByIndex(int index)
        {
            if (index <= ListSize && index > 0)
            {
                if (FindElem(index) != null)
                {
                    if (currentElem.index == index)
                    {
                        currentElem = currentElem.next;
                    }
                    else
                    {
                        VectorElem otherVector = currentElem;
                        while (currentElem.next.index != index)
                        {
                            currentElem = currentElem.next;
                        }
                        currentElem.next = currentElem.next.next;
                        currentElem = otherVector;
                    }
                }
            }
        }
        public Vector VectorAddition(Vector other)
        {
            int tempVectorSize = ListSize >= other.ListSize ? ListSize : other.ListSize;
            Vector tempVector = new Vector(tempVectorSize);
            for (int i = 1; i < tempVectorSize + 1; i++)
            {
                VectorElem firstVectorData = FindElem(i), secondVectorData = other.FindElem(i);
                if (firstVectorData != null && secondVectorData == null)
                {
                    tempVector.AssignValueByIndex(i, firstVectorData.data);
                }
                else if (firstVectorData == null && secondVectorData != null)
                {
                    tempVector.AssignValueByIndex(i, secondVectorData.data);
                }
                else if (firstVectorData != null && secondVectorData != null)
                {
                    tempVector.AssignValueByIndex(i, firstVectorData.data + secondVectorData.data);
                }
            }
            return tempVector;
        }
        public Vector VectorSubtraction(Vector other)           //?
        {
            return VectorAddition(Invert(other));
        }
        public Vector MultiplyNumber(double number)
        {
            Vector vector = new Vector(this);
            VectorElem vectorTemp = vector.currentElem;
            while (vectorTemp != null)
            {
                vectorTemp.data *= number;
                vectorTemp = vectorTemp.next;
            }
            return vector;
        }
        public double VectorAbs()
        {
            double sum = 0.0;
            for (int i = 1; i < ListSize + 1; i++)
            {
                VectorElem otherVector = FindElem(i);
                if (otherVector != null)
                {
                    sum += otherVector.data * otherVector.data;
                }
            }
            return Math.Sqrt(sum);
        }
        public double ScalarProduct(Vector other)       //?
        {
            double sum = 0.0;
            int tempVectorSize = ListSize >= other.ListSize ? ListSize : other.ListSize;
            for (int i = 1; i < tempVectorSize + 1; i++)
            {
                VectorElem firstVectorData = FindElem(i), secondVectorData = other.FindElem(i);
                if (firstVectorData != null && secondVectorData == null)
                {
                    sum += firstVectorData.data;
                }
                else if (firstVectorData == null && secondVectorData != null)
                {
                    sum += secondVectorData.data;
                }
                else if (firstVectorData != null && secondVectorData != null)
                {
                    sum += firstVectorData.data * secondVectorData.data;
                }
            }
            return sum;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Vector);
        }
        public bool Equals(Vector vector)           //?
        {
            if (ListSize != vector.ListSize)
            {
                return false;
            }
            VectorElem temp = currentElem, otherTemp = vector.currentElem;
            while (temp != null)
            {
                if (otherTemp == null || temp.data != otherTemp.data || temp.index != otherTemp.index)
                {
                    return false;
                }
                temp = temp.next;
                otherTemp = otherTemp.next;
            }
            return true;
        }

        public override string ToString()
        {
            StringBuilder indexesInString = new StringBuilder(), dataInString = new StringBuilder();
            VectorElem temp = currentElem;
            for (int i = 1; i < ListSize+1; i++)
            {
                if(i == temp.index)
                {
                    dataInString.Append(temp.data + " ");
                    temp = temp.next;
                }
                else
                {
                    dataInString.Append("0 ");
                }
                indexesInString.Append(i + " ");
            }
            return "Индексы: " + indexesInString + "\n" + " Данные: " + dataInString; 
        }
    }
}
