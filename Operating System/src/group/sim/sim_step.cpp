/*
 *  \author Rúben Lopes 103009, Pedro Gil Azevedo 102567        
 */

#include "somm23.h"

namespace group
{

// ================================================================================== //

    bool simStep()
    {
        soProbe(107, "%s()\n", __func__);
        
        if (feqIsEmpty()) return false;

        FutureEvent incoming = feqPop(); // get the next event
        simTime = incoming.time;
        if (incoming.type == ARRIVAL){
            ForthcomingProcess* process = simGetProcess(incoming.pid);  // get the process
            AddressSpaceProfile* profile = &(process->addressSpace);    // get the AdressSpaceProfile of the process
            pctInsert(process->pid, process->arrivalTime, process->lifetime, profile);
            AddressSpaceMapping* mapping = memAlloc(process->pid, profile);
            feqInsert(TERMINATE, simTime + process->lifetime, process->pid);
            pctUpdateState(process->pid,ACTIVE,simTime,mapping);
        }

        if (incoming.type == TERMINATE){
            AddressSpaceMapping* mapping = pctGetAddressSpaceMapping(incoming.pid);
            memFree(mapping);
            pctUpdateState(incoming.pid,FINISHED,simTime,mapping);
            while(swpPeek(0)!=NULL){
                SwappedProcess* swapped = swpPeek(0);
                AddressSpaceProfile* profile = pctGetAddressSpaceProfile(swapped->pid);
                AddressSpaceMapping* mapping = memAlloc(swapped->pid, profile);
                uint32_t lifetime = pctGetLifetime(swapped->pid);
                feqInsert(TERMINATE, simTime+lifetime,swapped->pid);
                pctUpdateState(swapped->pid,ACTIVE,simTime,mapping);
                swpRemove(0);
            }
        }
        stepCount++;
        return true;
    }
    

// ================================================================================== //

} // end of namespace group

