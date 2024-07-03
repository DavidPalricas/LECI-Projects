/*
 *  \author Rúben Lopes 103009
 */

#include "somm23.h"

    namespace group 
    {

// ================================================================================== //

    uint32_t pctGetLifetime(uint32_t pid)
    {
        soProbe(305, "%s(%u)\n", __func__, pid);

        require(pid > 0, "a valid process ID must be greater than zero");

        PctNode *p2 = pctHead;

        for(;p2 != NULL;p2 = p2->next){
            if(p2->pcb.pid == pid) break;
        }
        if(p2== NULL){ 
            printf("Process with pid %d not found.\n", pid);
            throw Exception(EINVAL,__func__);
        }
        return p2->pcb.lifetime;
    }

// ================================================================================== //

    AddressSpaceProfile *pctGetAddressSpaceProfile(uint32_t pid)
    {
        soProbe(306, "%s(%u)\n", __func__, pid);

        require(pid > 0, "a valid process ID must be greater than zero");

        PctNode *p2 = pctHead;

        for(;p2 != NULL;p2 = p2->next){
            if(p2->pcb.pid == pid) break;
        }
        if(p2== NULL){ 
            printf("Process with pid %d not found.\n", pid);
            throw Exception(EINVAL,__func__);
        }
        return &(p2->pcb.memProfile);
    }

// ================================================================================== //

    AddressSpaceMapping *pctGetAddressSpaceMapping(uint32_t pid)
    {
        soProbe(307, "%s(%u)\n", __func__, pid);

        require(pid > 0, "a valid process ID must be greater than zero");

        PctNode *p2 = pctHead;

        for(;p2 != NULL;p2 = p2->next){
            if(p2->pcb.pid == pid) break;
        }

        if(p2== NULL){ 
            printf("Process with pid %d not found.\n", pid);
            throw Exception(EINVAL,__func__);
        }
        return &(p2->pcb.memMapping);
    }

// ================================================================================== //

    const char *pctGetStateAsString(uint32_t pid)
    {
        soProbe(308, "%s(%u)\n", __func__, pid);

        require(pid > 0, "a valid process ID must be greater than zero");

        PctNode *p2 = pctHead;

        for(;p2 != NULL;p2 = p2->next){
            if(p2->pcb.pid == pid) break;
        }
        if(p2== NULL){ 
            printf("Process with pid %d not found.\n", pid);
            throw Exception(EINVAL,__func__);
        }
        switch (p2->pcb.state){
            case NEW:
                return "NEW";
            case ACTIVE:
                return "ACTIVE";
            case SWAPPED:
                return "SWAPPED";
            case FINISHED:
                return "FINISHED";
            case DISCARDED:
                return "DISCARDED";
            default:
                printf("Process with pid %d state not recognized.\n", pid);
                throw Exception(EINVAL,__func__);
            }
    }

// ================================================================================== //

} // end of namespace group

