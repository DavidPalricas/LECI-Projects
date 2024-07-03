/*
 *  \author Eduardo Alves, nº104179
 */

#include "somm23.h"

namespace group{

// ================================================================================== //

    void swpAdd(uint32_t pid, AddressSpaceProfile *profile)
    {
        soProbe(404, "%s(%u, %p)\n", __func__, pid, profile);

        require(pid > 0, "a valid process ID must be greater than zero");
        require(profile != NULL, "profile must be a valid pointer to a AddressSpaceProfile");

        /* TODO POINT: Replace next instruction with your code */
        SwpNode* newNode = new SwpNode;
        newNode->process.pid = pid;
        newNode->process.profile = *profile;
        newNode->next = nullptr;

        if(swpTail == nullptr && swpHead == nullptr){ /*No caso da lista ligada ser vazia*/
            swpTail = newNode;
            swpHead = newNode;
        }else{
            swpTail->next = newNode;/*Criar o nó no final da lista*/    
            swpTail = newNode; /*Designar o Node criado como tail*/
        
        }

        /*No caso do Node criado ser um campo Nulo, então há um erro*/
        if (newNode == nullptr) {
            throw Exception(ENOSYS, __func__);
        }
    }

// ================================================================================== //

} // end of namespace group

