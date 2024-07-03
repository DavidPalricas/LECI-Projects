/*
 *  \author Eduardo Alves: nº104179, David Palricas: nº108780, Mariana Silva: nº98392
 */

#include "somm23.h"
#include <stdio.h>
#include <stdint.h>


namespace group 
{
    

// ================================================================================== //

    void swpPrint(FILE *fout)
    {

        soProbe(403, "%s(\"%p\")\n", __func__, fout);

        require(fout != NULL and fileno(fout) != -1, "fout must be a valid file stream");

        /* TODO POINT: Replace next instruction with your code */
            
            
            fprintf(fout, "+===============================================+\n");
            fprintf(fout, "|             Swapped Process Queue             |\n");
            fprintf(fout, "+-------+---------------------------------------+\n");
            fprintf(fout, "|  PID  |         address space profile         |\n");
            fprintf(fout, "+-------+---------------------------------------+\n");
            
            SwpNode* current = swpHead; /* Instanciar o Nó inicial como head, para depois percorrer a linked list no while*/
            while (current != NULL){ /*Enquanto o elemento da linked list não é Null, imprimimos. Desta forma garantimos passar por todos os elementos da lista ligada. */
                switch (current->process.profile.segmentCount)
                {
                case 1:
                    fprintf(fout,"| %5d | %7d :   ---   :   ---   :   ---   |\n",current->process.pid,current->process.profile.size[0]);
                    break;

                case 2:
                    fprintf(fout,"| %5d | %7d : %7d :   ---   :   ---   |\n",current->process.pid,current->process.profile.size[0],current->process.profile.size[1]);
                    break;
                
                case 3:
                    fprintf(fout,"| %5d | %7d : %7d : %7d :   ---   |\n",current->process.pid,current->process.profile.size[0], current->process.profile.size[1], current->process.profile.size[2]);
                    break;
                case 4:
                    fprintf(fout,"| %5d | %7d : %7d : %7d : %7d |\n",current->process.pid,current->process.profile.size[0], current->process.profile.size[1], current->process.profile.size[2], current->process.profile.size[3]);
                default:
                    break;
                }
                current = current->next;    
                }
                fprintf(fout,"+===============================================+\n");

            fprintf(fout,"\n");

        
    }

// ================================================================================== //

} // end of namespace group