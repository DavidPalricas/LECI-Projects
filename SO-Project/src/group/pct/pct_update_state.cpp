/*
 *  \author Inês Santos 103477
 */

#include "somm23.h"

#include <stdint.h>

namespace group 
{

// ================================================================================== //

    void pctUpdateState(uint32_t pid, ProcessState state, uint32_t time = NO_TIME, AddressSpaceMapping *mapping = NULL)
    {
        soProbe(309, "%s(%d, %u, %u)\n", __func__, pid, state, time);

        require(pid > 0, "a valid process ID must be greater than zero");

        PctNode *p2 = pctHead;

        for(;p2 != NULL;p2 = p2->next){
            if(p2->pcb.pid == pid) break;
        }
        if(p2 == NULL){ 
            printf("Process with pid %d not found.\n", pid);
            throw Exception(EINVAL,__func__);
        }

        switch(state){
            case ACTIVE:
                p2->pcb.activationTime = time;
                p2->pcb.memMapping = *mapping;
                break;

            case FINISHED:
                p2->pcb.finishTime = time;
                break;
            default:
                throw Exception(EINVAL,__func__);            
        }

        p2->pcb.state = state;
    }

// ================================================================================== //

} // end of namespace group

