/*
 *  \author Eduardo Alves nº104179
 */

#include "somm23.h"

#include <stdio.h>
#include <stdint.h>

namespace group 
{

// ================================================================================== //
    
    void buddy_system_print_occupied_blocks(MemTreeNode * root, FILE *fout)
    {
        if (root == nullptr){
            return;
        }
            
        if (root->state == OCCUPIED) //Caso o bloco esteja ocupado
        {
            fprintf(fout,"| %7d | %#11x | %10d |\n",root->block.pid,root->block.address,root->block.size);
        }
        
        buddy_system_print_occupied_blocks(root->left, fout); //Procura recursivamente  a sub-árvore á esquerda da raiz
        buddy_system_print_occupied_blocks(root->right, fout); //Procura recursivamente  aa sub-árvore á direita da raiz
    }

    void buddy_system_print_free_blocks(MemTreeNode * root, FILE *fout)
    {
        if (root == nullptr){
            return;
        }
            
        if (root->state == FREE) //Caso o bloco esteja livre
        {
            fprintf(fout,"|   ---   | %#11x | %10d |\n",root->block.address,root->block.size);
        }
        
        buddy_system_print_free_blocks(root->left, fout); //Procura recursivamente  a sub-árvore á esquerda da raiz
        buddy_system_print_free_blocks(root->right, fout);//Procura recursivamente  aa sub-árvore á direita da raiz


    }
    void memPrint(FILE *fout)
    {
        soProbe(503, "%s(\"%p\")\n", __func__, fout);

        require(fout != NULL and fileno(fout) != -1, "fout must be a valid file stream");

        /* TODO POINT: Replace next instruction with your code */

        if(memParameters.policy == FirstFit){


          

            fprintf(fout,"+====================================+\n");
            fprintf(fout,"|   FirstFit memory occupied blocks  |\n");
            fprintf(fout,"+---------+-------------+------------+\n");
            fprintf(fout,"|   PID   |   address   |    size    |\n");
            fprintf(fout,"+---------+-------------+------------+\n");

            MemListNode * current = memOccupiedHead; /* Instanciar o Nó inicial como head, para depois percorrer a linked list no while*/

            while (current != NULL){ /*Enquanto o elemento da linked list não é Null, imprimimos. Desta forma garantimos passar por todos os elementos da lista ligada. */
                fprintf(fout,"| %7d | %#11x | %10d |\n",current->block.pid, current->block.address,current->block.size);
                current = current->next;
            }
            
            fprintf(fout,"+====================================+\n\n");
        
              //------------------------------------------------------------------------------------//

            fprintf(fout,"+====================================+\n");
            fprintf(fout,"|     FirstFit memory free blocks    |\n");
            fprintf(fout,"+---------+-------------+------------+\n");
            fprintf(fout,"|   PID   |   address   |    size    |\n");
            fprintf(fout,"+---------+-------------+------------+\n");
            
            current = memFreeHead; /* Instanciar o Nó inicial como head, para depois percorrer a linked list no while*/

            while (current != NULL){ /*Enquanto o elemento da linked list não é Null, imprimimos. Desta forma garantimos passar por todos os elementos da lista ligada. */
                fprintf(fout,"|   ---   | %#11x | %10d |\n" ,current->block.address,current->block.size);
                current = current->next;    
            }
        
            fprintf(fout,"+====================================+\n\n");

        }
        else if (memParameters.policy == BuddySystem){
            
            fprintf(fout,"+====================================+\n");
            fprintf(fout,"| BuddySystem memory occupied blocks |\n");
            fprintf(fout,"+---------+-------------+------------+\n");
            fprintf(fout,"|   PID   |   address   |    size    |\n");
            fprintf(fout,"+---------+-------------+------------+\n");

            MemTreeNode * root = memTreeRoot; /* Instanciar o Nó inicial como head, para depois percorrer a linked list no while*/
        
            buddy_system_print_occupied_blocks(root, fout);   
            
            fprintf(fout,"+====================================+\n\n");

         //------------------------------------------------------------------------------------//

             fprintf(fout,"+====================================+\n");
            fprintf(fout,"|   BuddySystem memory free blocks   |\n");
            fprintf(fout,"+---------+-------------+------------+\n");
            fprintf(fout,"|   PID   |   address   |    size    |\n");
            fprintf(fout,"+---------+-------------+------------+\n");

            root = memTreeRoot; /* Instanciar o Nó inicial como head, para depois percorrer a linked list no while*/
        
            buddy_system_print_free_blocks(root, fout);   
            
            fprintf(fout,"+====================================+\n\n");


        } 
    }

// ================================================================================== //

} // end of namespace group