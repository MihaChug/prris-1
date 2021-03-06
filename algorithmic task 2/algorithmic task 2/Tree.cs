﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithmic_task_2
{
    public class Tree
    {
        //конструктор класса
        public Tree()
        {
            m_topParent = new Root(' ', null); 
        }

        //добавление нового корня
        public void AddChild(string value)
        {
            Root currentParent = m_topParent;

            //каждая буква из переменной value добавляется в дерево
            foreach (char c in value)
            {
                //определяем, содержит ли родитель ребенка на текущую букву
                Root nextChild = currentParent.FindByValue(c);
                //если нет, то создаем и добавляем новый корень и указывает родителя, смещаем текущего родителя на нового
                if (nextChild == null)
                {
                    Root child = new Root(c, currentParent);
                    currentParent.SetChild(child);

                    

                    currentParent = child;
                }
                //иначе смещаемся вниз по дереву и меняем родителя
                else
                {
                    currentParent = nextChild;
                }
                
            }
            //последнюю букву отмечаем концом слова
            currentParent.SetWordEnd();    
        }

        //получение всех слов начинающихся на переменную word
        public int GetValueOfWordIncidence(string word)
        {
            Root currentParent = m_topParent;
            //продвигаемся по дереву через корни соответствующей буквы из переменной word, если корень с такой буквой не существует, следовательно возвращаем 0
            foreach (char c in word)
            {
                Root child = currentParent.FindByValue(c);   
                
                if (child == null)
                    return 0;

                currentParent = child;
            }
            int count = 0;
            //если данный корень является окончанием слова, увеличиваем счетчик
            if (currentParent.IsCurrentRootWordEnd())           
                count++;
            //добавляем к счетчику количество слов, начинающихся на переменную word
            count += currentParent.GetAllWordsEndInBranch();        
            return count;
        }

        Root m_topParent;
    }
}
