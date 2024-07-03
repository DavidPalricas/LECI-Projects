/*
 *  \author Pedro Gil Azevedo 102567
 */

#include "somm23.h"

namespace group 
{

// ================================================================================== //

    FutureEvent feqPop()
    {
        soProbe(205, "%s()\n", __func__);

        /* TODO POINT: Replace next instruction with your code */
        //throw Exception(ENOSYS, __func__);
        if (feqHead == NULL) {
        	throw Exception(EINVAL, __func__);
        }
        FutureEvent event = feqHead->event;
        feqHead = feqHead->next;
        return event;
        
    }

// ================================================================================== //

    bool feqIsEmpty()
    {
        soProbe(206, "%s()\n", __func__);

        /* TODO POINT: Replace next instruction with your code */
        //throw Exception(ENOSYS, __func__);
    	if (feqHead == NULL) {
    		return true;
    	} else {
    		return false;
    	}
    }

// ================================================================================== //

} // end of namespace group

