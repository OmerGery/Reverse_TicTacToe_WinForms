﻿using System;
using Ex02_Logic;
namespace Ex02_UI
{
    public class InputManager
    {
        public static string GetDataFromUser()
        {
            string userData = Console.ReadLine();
            return userData;
        }

        public static int GetValidNumFromUser(int i_MinValue, int i_MaxValue)
        {
            bool isValid = false;
            int validNum = 0;
            while (!isValid)
            {
                string userInput = GetDataFromUser();
                if (userInput == UI.k_QuitSymbolOne || userInput == UI.k_QuitSymbolTwo)
                {
                    UI.m_QSelected = true;
                    isValid = true;
                }
                else
                {
                    isValid = int.TryParse(userInput, out validNum);
                    if((validNum >= i_MinValue) && (validNum <= i_MaxValue))
                    {
                        isValid = true;
                    }
                    else
                    {
                        isValid = false;
                        OutputManager.PrintInvalidNumberError();
                    }
                }
            }
            
            return validNum;
        }

        public static void GetSquareFromPlayer(int i_BoardSize, ref Board.Square i_SelectedSquare)
        {
            OutputManager.PrintRequestForRow();
            int userRowChoice = GetValidNumFromUser(1, i_BoardSize);
            if(!UI.m_QSelected)
            {
                OutputManager.PrintRequestForCol();
                int userColChoice = GetValidNumFromUser(1, i_BoardSize);
                if(!UI.m_QSelected)
                {
                    i_SelectedSquare.m_Row = userRowChoice;
                    i_SelectedSquare.m_Col = userColChoice;
                }
            }
        }
    }
}