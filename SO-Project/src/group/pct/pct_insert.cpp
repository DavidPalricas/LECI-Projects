/*
 *  \author Rúben Lopes 103009
 */

#include "somm23.h"

#include <stdint.h>

namespace group 
{

// ================================================================================== //

    void pctInsert(uint32_t pid, uint32_t time, uint32_t lifetime, AddressSpaceProfile *profile)
    {
        soProbe(304, "%s(%d, %u, %u, %p)\n", __func__, pid, time, lifetime, profile);

        require(pid > 0, "a valid process ID must be greater than zero");
        require(time >= 0, "time must be >= 0");
        require(lifetime > 0, "lifetime must be > 0");
        require(profile != NULL, "profile must be a valid pointer to a AddressSpaceProfile");

        PctNode *newNode = new PctNode;
        PctNode *p1 = NULL, *p2 = pctHead;
        if (newNode == NULL){
            throw Exception(errno,__func__);
        }

        newNode->pcb.pid = pid; 
        newNode->pcb.state = NEW;
        newNode->pcb.arrivalTime = time;
        newNode->pcb.lifetime = lifetime;
        newNode->pcb.activationTime = NO_TIME;
        newNode->pcb.finishTime = NO_TIME;
        newNode->pcb.memProfile = *profile;
        AddressSpaceMapping *memSpaceMapping = new AddressSpaceMapping;
        memSpaceMapping->blockCount = 0;
        newNode->pcb.memMapping = *memSpaceMapping;

        // if(pctHead == NULL){
        //     pctHead = newNode;
        //     newNode->next = NULL;
        //     return;
        // }        
        
        for(; p2 != NULL; p1 = p2, p2 = p2->next){
            if(p2->pcb.pid < pid){
                continue;
            }
            if(p2->pcb.pid == pid){
                printf("Process with pid %d already exists.\n", pid);
                throw Exception(EINVAL,__func__);
            }
            if(p2->pcb.pid > pid){
                break;
            }
        }
        newNode->next = p2;
        if (p1 != NULL) {
            p1->next = newNode;
        } else {
            pctHead = newNode;
        }
        
    }

// ================================================================================== //

} // end of namespace group

