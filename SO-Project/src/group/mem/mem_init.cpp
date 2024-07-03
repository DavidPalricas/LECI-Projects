/*
 *  \author: Mariana Silva 98392 
 */

#include "somm23.h"

#include <stdint.h>

namespace group 
{

// ================================================================================== //

    uint32_t correct_mem(uint32_t buddy_mem_size) {
        
     
        uint32_t valor_pretendido = 1;
     

        while(buddy_mem_size > valor_pretendido){
            
            if(buddy_mem_size == valor_pretendido){ //Verifica se o valor da mem é um múltiplo de base de 2
                break;
            }
            
            valor_pretendido  = valor_pretendido << 1;

            
        }
        if(valor_pretendido> buddy_mem_size){
            valor_pretendido= valor_pretendido >> 1; // binary value fica o valor mais perto possivel do buddy mem size
            buddy_mem_size = valor_pretendido;
        }


        return buddy_mem_size;

    }
    


    void memInit(uint32_t mSize, uint32_t osSize, uint32_t cSize, AllocationPolicy policy) 
    {
        const char *pas = policy == FirstFit ? "FirstFit" : policy == BuddySystem ? "BuddySystem" : "Unkown";
        soProbe(501, "%s(%#x, %#x, %#x, %s)\n", __func__, mSize, osSize, cSize, pas);

        require(mSize > osSize, "memory must be bigger than the one use by OS");
        require((mSize % cSize) == 0, "memory size must be a multiple of chunck size");
        require((osSize % cSize) == 0, "memory size for OS must be a multiple of chunck size");
        require(policy == FirstFit or policy == BuddySystem, "policy must be FirstFit or BuddySystem");

        /* TODO POINT: Replace next instruction with your code */
        
        /*Instanciar Parametros*/
        memParameters.policy = policy;
        memParameters.totalSize = mSize;
        memParameters.chunkSize = cSize;
        memParameters.kernelSize =  osSize;

        if (policy == FirstFit){
            /*Instanciar a FirstFit*/
            memTreeRoot = nullptr;
            /*Instanciar a lista livre*/
            memFreeHead = new MemListNode;
            memFreeHead->block.pid = 0; /*Se o pid for 0 -> bloco está livre*/
            memFreeHead->block.size = (mSize - osSize);
            memFreeHead->block.address = osSize;
            memFreeHead->next = nullptr;
            memFreeHead->prev = nullptr;
            
            /*Instanciar a lista ocupada*/
            memOccupiedHead = nullptr;  
        }

        else if(policy == BuddySystem){

            /*Instanciar a BuddySystem*/
            memFreeHead = nullptr;
            memOccupiedHead = nullptr;
            /*Instanciar a Árvore*/            
            memTreeRoot = new MemTreeNode;
            memTreeRoot->state = FREE;
            memTreeRoot->block.pid = 0;        

            uint32_t buddy_mem_size = (mSize-osSize);


            buddy_mem_size =  correct_mem(buddy_mem_size);

   


            memTreeRoot->block.size = buddy_mem_size;
            memTreeRoot->block.address = osSize;
            memTreeRoot->left = nullptr;
            memTreeRoot->right = nullptr;
        }else{
            throw Exception(ENOSYS,__func__);
        }
    }

// ================================================================================== //

} // end of namespace group
