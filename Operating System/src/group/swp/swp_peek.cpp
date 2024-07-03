/*
 *  \author ...
 */

#include "somm23.h"

namespace group
{

// ================================================================================== //

    SwappedProcess *swpPeek(uint32_t idx)
    {
        soProbe(405, "%s(%u)\n", __func__, idx);

        uint32_t i = 0; //index da lista ligada

        /* TODO POINT: Replace next instruction with your code */
       
        SwpNode *current = swpHead;
        while (current != NULL)
        {
            if (i == idx)
            {
                return &(current->process);
            }
            current = current->next;
            i++;
        }
        return NULL; //caso não existe um elemnento no index especificado

            
        
       

        
        
    }

// ================================================================================== //

} // end of namespace group

