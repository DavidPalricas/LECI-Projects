/*
 *  \author Rúben Lopes 103009
 */

#include "somm23.h"

namespace group 
{

// ================================================================================== //

    void pctTerm() 
    {
        soProbe(302, "%s()\n", __func__);

        PctNode *p2 = pctHead;

        for(;p2 != NULL;p2 = p2->next){
            delete p2;                                                  //free current node
        }
        pctHead = NULL;                                                 //pctHead is NULL so there is an empty list
    }

// ================================================================================== //

} // end of namespace group

