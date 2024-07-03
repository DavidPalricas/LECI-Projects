/*
 *  \author Pedro Gil Azevedo 102567
 */

#include "somm23.h"

#include <stdio.h>
#include <stdint.h>

namespace group 
{

// ================================================================================== //

    void simPrint(FILE *fout)
    {
        soProbe(103, "%s(\"%p\")\n", __func__, fout);

        require(fout != NULL and fileno(fout) != -1, "fout must be a valid file stream");

        /* TODO POINT: Replace next instruction with your code */
        //throw Exception(ENOSYS, __func__);
        printf("+====================================================================+\n");
        printf("|                          forthcomingTable                          |\n");
        printf("+-------+---------+----------+---------------------------------------+\n");
        printf("|    Simulation step: %6u |              Simulation time: %7u |\n",stepCount, simTime);
        printf("+-------+---------+----------+---------------------------------------+\n");
        printf("|  PID  | arrival | lifetime |         address space profile         |\n");
        printf("+-------+---------+----------+---------------------------------------+\n");
        for (uint32_t i = 0; i < forthcomingTable.count; i++) {
        	printf("| %5u | %7u | %8u |",forthcomingTable.process[i].pid,forthcomingTable.process[i].arrivalTime,forthcomingTable.process[i].lifetime);
        	uint32_t counter = forthcomingTable.process[i].addressSpace.segmentCount;
        	for( uint32_t j = 0; j < MAX_SEGMENTS; j++ ) {
        		if ( counter > 0) {
        			printf(" %7u ",forthcomingTable.process[i].addressSpace.size[j]);
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
        	printf("\n");
        }
        
        
        printf("+====================================================================+\n");
        printf("\n");
        /*
	

	

        */
    }

// ================================================================================== //

} // end of namespace group

