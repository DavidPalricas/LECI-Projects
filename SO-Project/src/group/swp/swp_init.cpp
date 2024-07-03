/*
 *  \author ...
 */

#include "somm23.h"

namespace group
{

// ================================================================================== //

    /*
     * \brief Init the module's internal data structure
     */
    void swpInit()
    {
        soProbe(401, "%s()\n", __func__);

        /* TODO POINT: Replace next instruction with your code */
        swpHead = NULL;
        swpTail = NULL;
        //throw Exception(ENOSYS, __func__);
    }

// ================================================================================== //

} // end of namespace group

