/*
 *  \author David Palricas,108780
 */

#include "somm23.h"

namespace group 
{

// ================================================================================== //
    void delete_bin_tree(MemTreeNode * root)
    {
        if (root == nullptr){
            return;
        }      

        delete_bin_tree(root->left); //Remove recursivamente as sub-árvores á esquerda da raiz
        delete_bin_tree(root->right); //Remove recursivamente  as sub-árvores á  direita da raiz
        delete root;
    }

    void delete_linked_list(MemListNode *head){
       
        while (head != nullptr)
        {
            MemListNode * current = head;
            head = head->next;
            delete current;
        }
        
    }

    void memTerm() 
    {
        soProbe(502, "%s()\n", __func__);

        /* TODO POINT: Replace next instruction with your code */
        AllocationPolicy policy = memParameters.policy;
        

        if (policy == FirstFit)
        {  
            delete_linked_list(memFreeHead);
            delete_linked_list(memOccupiedHead);
            
        }
        else if(policy == BuddySystem){
            /*Resetar a BuddySystem*/
             delete_bin_tree(memTreeRoot); //Função recursiva que apaga todos os nós da árvore
        }
        else{
            throw Exception(ENOSYS, __func__);
        }
    }

// ================================================================================== //

} // end of namespace group 