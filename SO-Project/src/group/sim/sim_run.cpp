/*
 *  \author Inês Santos 103477
 */

#include "somm23.h"

namespace group
{

// ================================================================================== //

    void simRun(uint32_t cnt)
    {
        soProbe(108, "%s(%u)\n", __func__, cnt);

        /* TODO POINT: Replace next instruction with your code */
        /* Run the simulation for a given number of steps. 
            This function just call the simStep a number of times.
        The following must be considered:
            -> The simulation can reach the end in less than the given number of steps.
            -> If the given number of steps is zero, the simulation must run til the end.*/
        
        // Run the simulation for a given number of steps.

        if(cnt == 0){
                while(simStep()); // simulation must run til the end
        }else{
        for(uint32_t i = 0; i < cnt; i++){
            if (!simStep()) break;
        }

        //throw Exception(ENOSYS, __func__);
    }

// ================================================================================== //

} // end of namespace group

}
