using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Collections;

namespace Lab4Activity1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //taking user input from rich textbox
            String userInput = tfInput.Text;


            //List of keywords which will be used to seperate keywords from variables
            List<String> keywordList = new List<String>();
            keywordList.Add("int");
            keywordList.Add("float");
            keywordList.Add("while");
            keywordList.Add("main");
            keywordList.Add("if");
            keywordList.Add("else");
            keywordList.Add("new");


            //row is an index counter for symbol table
            int row = 1;

            //count is a variable to incremenet variable id in tokens 
            int count = 1;

            //line_num is a counter for lines in user input 
            int line_num = 0;

            //SymbolTable is a 2D array that has the following structure
            //[Index][Variable Name][type][value][line#]
            //rows are incremented with each variable information entry

            String[,] SymbolTable = new String[20, 6];
            /*List<String> varListinSymbolTable = new List<String>();*/

            //Input Buffering
            ArrayList finalArray = new ArrayList();
            ArrayList finalArrayc = new ArrayList();
            ArrayList tempArray = new ArrayList();



            //Converting the user input into an array of characters
            char[] charinput = userInput.ToCharArray();

            //Regular Expression for Variables Classification
            Regex variable_Reg = new Regex(@"^[A-Za-z|_][A-Za-z|0-9]*$");

            //Regular Expression for Constants Classfication
            Regex constants_Reg = new Regex(@"^[0-9]+([.][0-9]+)?([e]([+|-])?[0-9]+)?$");

            //Regular Expression for Operators Classfication
            Regex operators_Reg = new Regex(@"^[-*+/><&&||=]$");

            //Regular Expression for Special_Characters Classfication
            Regex Special_Reg = new Regex(@"^[.,'\[\]{}();:?]$");

            for (int itr = 0; itr < charinput.Length; itr++)
            {
                //Matching the characters with the regex
                Match Match_Variable = variable_Reg.Match(charinput[itr] + "");
                Match Match_Constant = constants_Reg.Match(charinput[itr] + "");
                Match Match_Operator = operators_Reg.Match(charinput[itr] + "");
                Match Match_Special = Special_Reg.Match(charinput[itr] + "");

                //If regex matches, add it to tempArray
                if (Match_Variable.Success || Match_Constant.Success || Match_Operator.Success || Match_Special.Success || charinput[itr].Equals(' '))
                {
                    tempArray.Add(charinput[itr]);
                }
                //If character is a line break character
                if (charinput[itr].Equals('\n'))
                {
                    //If tempArray is not empty
                    if (tempArray.Count != 0)
                    {
                        // Get all chacters in the temp array and combine them in a string
                        int j = 0;
                        String fin = "";
                        for (; j < tempArray.Count; j++)
                        {
                            fin += tempArray[j];
                        }
                        // Add the string in the finalArray
                        finalArray.Add(fin);

                        // Empty the tempArray
                        tempArray.Clear();
                    }
                }
            }

            //If tempArray is not empty
            if (tempArray.Count != 0)
            {
                // Get all chacters in the temp array and combine them in a string
                int j = 0;
                String fin = "";
                for (; j < tempArray.Count; j++)
                {
                    fin += tempArray[j];
                }
                // Add the string in the finalArray
                finalArray.Add(fin);

                // Empty the tempArray
                tempArray.Clear();
            }

            // Clearing the symbol table
            this.symbolTable.Clear();

            // Clearing the token table
            tfToken.Clear();

            //looping through all the lines in the finalArray
            for (int i = 0; i < finalArray.Count; i++)
            {
                //Get a line in the array and convert it to string
                String line = finalArray[i].ToString();

                //Convert the line into an array of characters
                char[] lineChar = line.ToCharArray();

                //Incrementing line number
                line_num++;

                //taking current line and splitting it into lexemes by space
                for (int itr = 0; itr < lineChar.Length; itr++)
                {
                    //Matching the characters with the regex
                    Match Match_Variable = variable_Reg.Match(lineChar[itr] + "");
                    Match Match_Constant = constants_Reg.Match(lineChar[itr] + "");
                    Match Match_Operator = operators_Reg.Match(lineChar[itr] + "");
                    Match Match_Special = Special_Reg.Match(lineChar[itr] + "");

                    //If regex matches with variable or constant, add it to tempArray
                    if (Match_Variable.Success || Match_Constant.Success)
                    {
                        tempArray.Add(lineChar[itr]);
                    }
                    //If the character is equal to a space character
                    if (lineChar[itr].Equals(' '))
                    {
                        //Combine all the letters in the tempArray and convert it into string and add it to finalArrayc
                        if (tempArray.Count != 0)
                        {
                            int j = 0;
                            String fin = "";
                            for (; j < tempArray.Count; j++)
                            {
                                fin += tempArray[j];
                            }
                            finalArrayc.Add(fin);
                            tempArray.Clear();
                        }
                    }
                    //If the character matches an operator or special characters
                    if (Match_Operator.Success || Match_Special.Success)
                    {
                        //Combine all the letters in the tempArray and convert it into string and add it to finalArrayc
                        if (tempArray.Count != 0)
                        {
                            int j = 0;
                            String fin = "";
                            for (; j < tempArray.Count; j++)
                            {
                                fin += tempArray[j];
                            }
                            finalArrayc.Add(fin);
                            tempArray.Clear();
                        }

                        //Adding the operator in the finalArrayc as well
                        finalArrayc.Add(lineChar[itr]);
                    }
                }


                //Combine all the letters in the tempArray and convert it into string and add it to finalArrayc
                if (tempArray.Count != 0)
                {
                    String fina = "";
                    for (int k = 0; k < tempArray.Count; k++)
                    {
                        fina += tempArray[k];
                    }

                    finalArrayc.Add(fina);
                    tempArray.Clear();
                }


                // we have a splitted line here
                for (int x = 0; x < finalArrayc.Count; x++)
                {

                    Match operators = operators_Reg.Match(finalArrayc[x].ToString());
                    Match variables = variable_Reg.Match(finalArrayc[x].ToString());
                    Match digits = constants_Reg.Match(finalArrayc[x].ToString());
                    Match punctuations = Special_Reg.Match(finalArrayc[x].ToString());

                    if (operators.Success)
                    {
                        // if a current lexeme is an operator then make a token e.g. < op, = >
                        this.symbolTable.AppendText("< op, " + finalArrayc[x].ToString() + "> ");
                        if (!tfToken.Text.Contains(finalArrayc[x].ToString()))
                        {
                            this.tfToken.AppendText(finalArrayc[x].ToString() + "\n");
                        }
                    }
                    else if (digits.Success)
                    {
                        // if a current lexeme is a digit then make a token e.g. < digit, 12.33 >
                        this.symbolTable.AppendText("< digit, " + finalArrayc[x].ToString() + "> ");
                    }
                    else if (punctuations.Success)
                    {
                        // if a current lexeme is a punctuation then make a token e.g. < punc, ; >
                        this.symbolTable.AppendText("< punc, " + finalArrayc[x].ToString() + "> ");
                    }
                    else if (variables.Success)
                    {
                        // if a current lexeme is a variable and not a keyword 
                        if (!keywordList.Contains(finalArrayc[x].ToString())) // if it is not a keyword
                        {
                            // check what is the category of varaible, handling only two cases here
                            //Category1- Variable initialization of type digit e.g. int count = 10 ;
                            //Category2- Variable initialization of type String e.g. String var = ' Hello ' ;             

                            Regex reg1 = new Regex(@"^(int|String|float|double)\s([A-Za-z|_][A-Za-z|0-9]{0,10})\s(=)\s([0-9]+([.][0-9]+)?([e][+|-]?[0-9]+)?)(;?)$"); // line of type int alpha = 2 ;
                            Match category1 = reg1.Match(line);

                            Regex reg2 = new Regex(@"^(String|char)\s([A-Za-z|_][A-Za-z|0-9]{0,10})\s(=)\s[']\s([A-Za-z|_][A-Za-z|0-9]{0,30})\s['](;?)$"); // line of type String alpha = ' Hello ' ;
                            Match category2 = reg2.Match(line);

                            //if it is a category 1 then add a row in symbol table containing the information related to that variable

                            if (category1.Success)
                            {
                                SymbolTable[row, 1] = row.ToString(); //index

                                SymbolTable[row, 2] = finalArrayc[x].ToString(); //variable name

                                SymbolTable[row, 3] = finalArrayc[x - 1].ToString(); //type

                                SymbolTable[row, 4] = finalArrayc[x + 2].ToString(); //value

                                SymbolTable[row, 5] = line_num.ToString(); // line number

                                this.symbolTable.AppendText("<var" + count + ", " + row + "> ");
                              /*  tfToken.AppendText(SymbolTable[row, 1].ToString() + " \t ");
                                tfToken.AppendText(SymbolTable[row, 2].ToString() + " \t ");
                                tfToken.AppendText(SymbolTable[row, 3].ToString() + " \t ");
                                tfToken.AppendText(SymbolTable[row, 4].ToString() + " \t ");
                                tfToken.AppendText(SymbolTable[row, 5].ToString() + " \n ");*/
                                row++;
                                count++;
                            }
                            //if it is a category 2 then add a row in symbol table containing the information related to that variable
                            else if (category2.Success)
                            {
                                // if  a line such as String var = ' Hello ' ; comes and the loop moves to index of array containing Hello ,
                                //then this if condition prevents addition of Hello in symbol Table because it is not a variable it is just a string

                                if (!(finalArrayc[x - 1].ToString().Equals("'") && finalArrayc[x + 1].ToString().Equals("'")))

                                {
                                    SymbolTable[row, 1] = row.ToString(); // index

                                    SymbolTable[row, 2] = finalArrayc[x].ToString(); //varname

                                    SymbolTable[row, 3] = finalArrayc[x - 1].ToString(); //type

                                    SymbolTable[row, 4] = finalArrayc[x + 3].ToString(); //value

                                    SymbolTable[row, 5] = line_num.ToString(); // line number

                                    this.symbolTable.AppendText("<var" + count + ", " + row + "> ");
                                    /*tfToken.AppendText(SymbolTable[row, 1].ToString() + " \t ");
                                    tfToken.AppendText(SymbolTable[row, 2].ToString() + " \t ");
                                    tfToken.AppendText(SymbolTable[row, 3].ToString() + " \t ");
                                    tfToken.AppendText(SymbolTable[row, 4].ToString() + " \t ");
                                    tfToken.AppendText(SymbolTable[row, 5].ToString() + " \n ");*/
                                    row++;
                                    count++;
                                }
                                else
                                {
                                    this.symbolTable.AppendText("<String" + count + ", " + finalArrayc[x].ToString() + "> ");
                                }

                            }

                            else
                            {
                                // if any other category line comes in we check if we have initializes that varaible before,
                                // if we have initiazed it before then we put the index of that variable in symbol table, in its token
                                String ind = "Default";
                                String ty = "Default";
                                String val = "Default";
                                String lin = "Default";

                                for (int r = 1; r < row; r++)
                                {
                                    //search in the symbol table if variable entry already exists
                                    if (SymbolTable[r, 2].Equals(finalArrayc[x].ToString()))
                                    {
                                        ind = SymbolTable[r, 1];
                                        ty = SymbolTable[r, 3];
                                        val = SymbolTable[r, 4];
                                        lin = SymbolTable[r, 5];
                                        this.symbolTable.AppendText("<var" + ind + ", " + ind + "> ");

                                        break;
                                    }
                                }
                            }

                        }
                        // if a current lexeme is not a variable but a keyword then make a token such as: <keyword, int>
                        else
                        {
                            this.symbolTable.AppendText("<keyword, " + finalArrayc[x].ToString() + "> ");
                        }
                    }
                }
                this.symbolTable.AppendText("\n");
                finalArrayc.Clear();
            }
        }
    }
}
