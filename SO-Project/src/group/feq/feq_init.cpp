/*
 *  \author Pedro Gil Azevedo 102567
 */

#include "somm23.h"

#include <stdint.h>

namespace group 
{

// ================================================================================== //

    void feqInit()
    {
        soProbe(201, "%s()\n", __func__);
	
        /* TODO POINT: Replace next instruction with your code */
        feqHead = NULL;
        // throw Exception(ENOSYS, __func__);
    }

// ================================================================================== //

} // end of namespace group

