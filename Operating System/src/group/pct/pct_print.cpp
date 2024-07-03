/*
 *  \author Rúben Lopes 103009
 */

#include "somm23.h"

#include <stdio.h>
#include <stdint.h>

namespace group 
{

// ================================================================================== //

    void pctPrint(FILE *fout)
    {
        soProbe(303, "%s(\"%p\")\n", __func__, fout);

        require(fout != NULL and fileno(fout) != -1, "fout must be a valid file stream");

        fprintf(fout,"+====================================================================================================================================================+\n");
        fprintf(fout,"|                                                                  Process Control Table                                                             |\n");
        fprintf(fout,"+-------+-----------+---------+----------+---------+---------+---------------------------------------+-----------------------------------------------+\n");
        fprintf(fout,"|  PID  |   state   | arrival | lifetime | active  | finish  |         address space profile         |             address space mapping             |\n");
        fprintf(fout,"+-------+-----------+---------+----------+---------+---------+---------------------------------------+-----------------------------------------------+\n");
        PctNode *p2 = pctHead;

        for(;p2 != NULL;p2 = p2->next){
            if(p2->pcb.state == NEW) continue;
            int pid = p2->pcb.pid;
            const char * state = pctGetStateAsString(pid);
            int arrival = p2->pcb.arrivalTime;
            int lifetime = p2->pcb.lifetime;
            int active = p2->pcb.activationTime;
            int finish = p2->pcb.finishTime;
            if (finish == -1 ) {
                fprintf(fout,"|%6d | %-9s |%8d |%9d |%8d |   ---   |",pid,state,arrival,lifetime,active);
            } else {
                fprintf(fout,"|%6d | %-9s |%8d |%9d |%8d |%8d |",pid,state,arrival,lifetime,active,finish);
            }

            uint32_t counter = p2->pcb.memProfile.segmentCount;
            for( uint32_t j = 0; j < MAX_SEGMENTS; j++ ) {
                if ( counter > 0) {
                    printf("%8u ",p2->pcb.memProfile.size[j]);
                    counter -= 1;
                } else {
                    printf("   ---   ");
                }
                if (j == MAX_SEGMENTS-1) {
                    printf("|");
                } else {
                    printf(":");
                }
            }

            counter = p2->pcb.memMapping.blockCount;
            for( uint32_t j = 0; j < MAX_BLOCKS; j++ ) {
                if ( counter > 0) {
                    printf(" %#09x ",p2->pcb.memMapping.address[j]);
                    counter -= 1;
                } else {
                    printf("    ---    ");
                }
                if (j == MAX_BLOCKS-1) {
                    printf("|");
                } else {
                    printf(":");
                }
            }
            printf("\n");
             
            
        }
        fprintf(fout,"+====================================================================================================================================================+\n");
        printf("\n");
    }

// ================================================================================== //

} // end of namespace group

