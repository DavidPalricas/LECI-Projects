/*
 *  \author Mariana Silva, nº98392
 */

#include "somm23.h"

namespace group
{

// ================================================================================== //

    void swpTerm()
    {
        soProbe(402, "%s()\n", __func__);

        /* TODO POINT: Replace next instruction with your code */

        SwpNode* current = swpHead;
        while (current != NULL) {
            SwpNode* next = current->next;
            delete current;
            current = next;
        }
        // Reinicializar os ponteiros para indicar uma lista vazia
        swpHead = NULL;
        swpTail = NULL;

        if (swpHead != nullptr || swpTail != nullptr){
            throw Exception(ENOSYS, __func__);
        }
    }

// ================================================================================== //

} // end of namespace group
