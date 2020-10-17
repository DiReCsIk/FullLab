using System;
using FirstLab;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestFirstLab
{
    [TestClass]
    public class VectorTest
    {
        /*
         * Тест переопределенного метода Equals()
         */
        [TestMethod]
        public void Equals_Test()
        {
            Vector firstVector = new Vector(3), secondVector = new Vector(3);

            firstVector.AssignValueByIndex(1, 5);
            firstVector.AssignValueByIndex(3, 4);

            secondVector.AssignValueByIndex(1, 5);
            secondVector.AssignValueByIndex(3, 4);

            Assert.AreEqual(firstVector, secondVector);
        }
        /*
        * Тест конструктора копирования
        */
        [TestMethod]
        public void Copy_Constr_Test()
        {
            Vector firstVector = new Vector(1);
            firstVector.AssignValueByIndex(1, 1);

            Vector secondVector = new Vector(firstVector);

            Assert.AreEqual(firstVector, secondVector);
        }
        /*
         * Тест на добавление 0 (является удалением)
        */
        [TestMethod]
        public void Check_Add_Elem_With_Zero_In_Data()
        {
            Vector firstVector = new Vector(3),
                   secondVector = new Vector(3);

            firstVector.AssignValueByIndex(1, 4);
            firstVector.AssignValueByIndex(2, 5);

            secondVector.AssignValueByIndex(1, 4);
            secondVector.AssignValueByIndex(2, 5);
            secondVector.AssignValueByIndex(3, 6);
            secondVector.AssignValueByIndex(3, 0);

            Assert.AreEqual(firstVector, secondVector);
        }
        /*
         * Тест на добавление элемента под индексом, который уже есть в списке (является заменой элемента)
         */
        [TestMethod]
        public void Check_Add_Elem_With_Same_Index()
        {
            Vector firstVector = new Vector(3),
                   secondVector = new Vector(3);

            firstVector.AssignValueByIndex(1, 4);
            firstVector.AssignValueByIndex(2, 5);

            secondVector.AssignValueByIndex(1, 4);
            secondVector.AssignValueByIndex(2, 10);
            secondVector.AssignValueByIndex(2, 5);

            Assert.AreEqual(firstVector, secondVector);
        }
        /*
        * Проверка переопределенного метода ToString()
        */
        [TestMethod]
        public void Check_To_String()
        {
            Vector firstVector = new Vector(3);

            firstVector.AssignValueByIndex(1, 5);
            firstVector.AssignValueByIndex(3, 4);

            String expected = "Индексы: 1 2 3 " + "\n" + " Данные: " + "5 0 4 ";

            Assert.AreEqual(expected, firstVector.ToString());
        }
        /*
         * Тест сложения векторов
         */
        [TestMethod]
        public void Check_Vectors_Addition()
        {
            Vector firstVector = new Vector(3),
                   secondVector = new Vector(3),
                   expectedVector = new Vector(3);

            firstVector.AssignValueByIndex(1, 4);
            firstVector.AssignValueByIndex(2, 5);

            secondVector.AssignValueByIndex(1, 4);
            secondVector.AssignValueByIndex(3, 10);

            expectedVector.AssignValueByIndex(1, 8);
            expectedVector.AssignValueByIndex(2, 5);
            expectedVector.AssignValueByIndex(3, 10);

            Assert.AreEqual(expectedVector, firstVector.VectorAddition(secondVector));
        }
        /*
         * Тест вычитания векторов
         */
        [TestMethod]
        public void Check_Vectors_Subtraction()
        {
            Vector firstVector = new Vector(3),
                   secondVector = new Vector(3),
                   expectedVector = new Vector(3);

            firstVector.AssignValueByIndex(1, 4);
            firstVector.AssignValueByIndex(2, 5);

            secondVector.AssignValueByIndex(1, 4);
            secondVector.AssignValueByIndex(3, 10);

            expectedVector.AssignValueByIndex(1, 0);
            expectedVector.AssignValueByIndex(2, 5);
            expectedVector.AssignValueByIndex(3, -10);

            Assert.AreEqual(expectedVector, firstVector.VectorSubtraction(secondVector));
        }
        /*
         * Тест умножения вектора на число
         */
        [TestMethod]
        public void Check_Vector_Multiply_With_Number()
        {
            int number = 3;
            Vector firstVector = new Vector(3),
                   expectedVector = new Vector(3);

            firstVector.AssignValueByIndex(1, 4);
            firstVector.AssignValueByIndex(2, 5);

            expectedVector.AssignValueByIndex(1, 4 * number);
            expectedVector.AssignValueByIndex(2, 5 * number);

            Assert.AreEqual(expectedVector, firstVector.MultiplyNumber(number));
        }
        /*
        * Проверка модуля пустого вектора
        */
        [TestMethod]
        public void Check_Vector_Absolute_With_Number()
        {
            Vector firstVector = new Vector(10);

            double expected = 0.0;

            Assert.AreEqual(expected, firstVector.VectorAbs());
        }
        /*
        * Проверка модуля вектора
        */
        [TestMethod]
        public void Check_Vector_Absolute()
        {
            Vector firstVector = new Vector(3);

            double expected = 3.0;

            firstVector.AssignValueByIndex(1, 1);
            firstVector.AssignValueByIndex(2, 2);
            firstVector.AssignValueByIndex(3, 2);

            Assert.AreEqual(expected, firstVector.VectorAbs());
        }
        /*
        * Проверка скалярного произвидения
        */
        [TestMethod]
        public void Check_Vectors_Scalar_Product()
        {

            Vector firstVector = new Vector(3),
                   secondVector = new Vector(3);

            double expected = 6.0;

            firstVector.AssignValueByIndex(1, 1);
            firstVector.AssignValueByIndex(2, 2);
            firstVector.AssignValueByIndex(3, 1);

            secondVector.AssignValueByIndex(1, 2);
            secondVector.AssignValueByIndex(2, 1);
            secondVector.AssignValueByIndex(3, 2);

            Assert.AreEqual(expected, firstVector.ScalarProduct(secondVector));
        }
        /*
       * Проверка на сложение пустых векторов
       */
        [TestMethod]
        public void Check_Empty_Vectors_Addition()
        {
            Vector firstVector = new Vector(3),
                  secondVector = new Vector(3),
                  expected = new Vector(3);
            Assert.AreEqual(expected, firstVector.VectorAddition(secondVector));
        }
        /*
        * Проверка на вычитание пустых векторов
        */
        [TestMethod]
        public void Check_Empty_Vectors_Subtraction()
        {

            Vector firstVector = new Vector(3),
                  secondVector = new Vector(3),
                  expected = new Vector(3);
            Assert.AreEqual(expected, firstVector.VectorSubtraction(secondVector));
        }
        /*
         * Проверка скалярного произвидения пустых векторов
         */
        [TestMethod]
        public void Check_Empty_Vectors_Scalar_Product()
        {
            Vector firstVector = new Vector(3),
                  secondVector = new Vector(3);
            double expected = 0.0;
            Assert.AreEqual(expected, firstVector.ScalarProduct(secondVector));
        }
    }

}
