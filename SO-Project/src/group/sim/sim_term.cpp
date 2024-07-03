/*
 *  \author Inês Santos 103477
 */

#include "somm23.h"

namespace group 
{

// ================================================================================== //

    void simTerm() 
    {
        soProbe(102, "%s()\n", __func__);
        
        /* Reset the internal data structure of all module to the initial state.
            After calling the termination functions of the other modules, 
            the supporting data structure must be reset to the initial state. */
        memTerm();
        swpTerm();
        pctTerm();
        feqTerm();
        
        
        // for(uint32_t i = 0; i < forthcomingTable.count; i++){
        //     delete &(forthcomingTable.process[i]);
        // }
                                                      
        forthcomingTable.count = 0;
        
        //throw Exception(ENOSYS, __func__);
    }

// ================================================================================== //

} // end of namespace group


