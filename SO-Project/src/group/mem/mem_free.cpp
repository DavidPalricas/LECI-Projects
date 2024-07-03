/*
 *  \author David Palricas 108780, Mariana Silva 98392
 */

#include "somm23.h"

#include <stdint.h>

namespace group 
{

// ================================================================================== //

    void memFree(AddressSpaceMapping *mapping)
    {
        soProbe(507, "%s(mapping: %p)\n", __func__, mapping);

        require(mapping != NULL, "mapping must be a valid pointer to a AddressSpaceMapping");

        AllocationPolicy usedPolicy = memParameters.policy;

        if(usedPolicy == FirstFit){
            for(uint32_t i = 0; i < mapping->blockCount; ++i){
                memFirstFitFree(mapping->address[i]);
            }
        }

        else if(usedPolicy == BuddySystem){
            for(uint32_t i = 0; i < mapping->blockCount; ++i){
                memBuddySystemFree(mapping->address[i]);
            }
        }

        else if(usedPolicy != FirstFit && usedPolicy != BuddySystem){
            throw Exception(EINVAL, __func__);
        }
    }

// ================================================================================== //

} // end of namespace group
