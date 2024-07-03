/*
 *  \author Pedro Gil Azevedo 102567
 */

#include "somm23.h"

namespace group 
{

// ================================================================================== //

    void feqTerm() 
    {
        soProbe(202, "%s()\n", __func__);

        /* TODO POINT: Replace next instruction with your code */
        //throw Exception(ENOSYS, __func__);
        FeqEventNode *p2 = feqHead;
        for(;p2!=NULL;p2=p2->next) {
        	delete p2;
        }
        feqHead = NULL;
    }

// ================================================================================== //

} // end of namespace group

