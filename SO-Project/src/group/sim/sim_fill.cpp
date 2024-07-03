/*
 *  \author Inês Santos 103477, Rúben Lopes 103009          
 */

#include "somm23.h"
#include <unistd.h>

namespace group
{

// ================================================================================== //

    void simRandomFill(uint32_t n, uint32_t seed)
    {
        soProbe(105, "%s(%u, %u)\n", __func__, n, seed);

        require(n == 0 or n >= 2, "At least 2 processes are required");
        require(n <= MAX_PROCESSES, "More than MAX_PROCESSES processes not allowed");

        if (seed == 0)  {
            seed = getpid(); 
            // printf("seed: %u\n", seed);
            }

        else            srand(seed);
        
        if (n == 0) {
            forthcomingTable.count = rand() % MAX_PROCESSES + 2; 
        }else {
            forthcomingTable.count = n;
        }
        uint32_t arrival = 0;
        uint32_t pid;
        uint32_t segmentCount;
        for(uint32_t i = 0; i < forthcomingTable.count; i++) { 
            
            arrival += rand() % 100; 
            pid = rand() % 65535 + 1;
            segmentCount = rand() % MAX_SEGMENTS + 1;
            
            forthcomingTable.process[i].pid = pid;
            forthcomingTable.process[i].lifetime = rand() % 1000 + 10;
            forthcomingTable.process[i].arrivalTime = arrival;
            forthcomingTable.process[i].addressSpace.segmentCount = segmentCount;
        

            for(uint32_t k = 0; k < segmentCount; k++) {
                forthcomingTable.process[i].addressSpace.size[k] = rand() % 0x800 + 0x100; // TO DO [0x100, 0x800];
            }
            feqInsert(ARRIVAL, arrival, pid);       // insert in the event queue 
        }
            
    }

// ================================================================================== //

} 
// end of namespace group