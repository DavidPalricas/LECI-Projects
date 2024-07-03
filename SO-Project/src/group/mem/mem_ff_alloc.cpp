/*
 *  \author... Eduardo Alves nº104179
               David Palricas nº108780
 */

#include "somm23.h"

#include <stdint.h>

namespace group 
{

// ================================================================================== //

    Address memFirstFitAlloc(uint32_t pid, uint32_t size)
    {
        soProbe(505, "%s(%u, %#x)\n", __func__, pid, size);

        require(pid > 0, "a valid process ID must be greater than zero");
        require(size, "the size of a memory segment must be greater then zero");

        if (pid == 0){
            throw Exception(EINVAL, __func__);
        }

        /* TODO POINT: Replace next instruction with your code */
        MemListNode *current = new MemListNode;
        current = memFreeHead; /*Inicializar a current como a Head da lista livre*/

            // 
            MemListNode *newListNode = nullptr;
            while (current != nullptr)
            {
                // The first free block, big enough to accommodate the requested size, must be used, Iniciamos também o novo Node criado com os valores corretos.
                if (size <= current->block.size)
                {
                    newListNode = new MemListNode;
                    newListNode->block.pid = pid;
                    newListNode->block.size = size;
                    newListNode->block.address = current->block.address;
                    current->block.address = current->block.address + size; //Está a percorrer por ordem, pois somamos o size do bloco removido, passando assim para o proximo bloco
                    current->block.size = current->block.size - size;
                    break;
                }
                current = current->next;
            }

            if (newListNode != nullptr){
                // Se a lista for vazia, insere o novo elemento na lista
                if (memOccupiedHead == nullptr){
                    memOccupiedHead = newListNode;
                    newListNode->next = nullptr;
                    return newListNode->block.address;
                }
                // Inserir por ordem ascendente de addresses
                MemListNode *latest_Allocated_Node = memOccupiedHead;

                while (latest_Allocated_Node->next != nullptr && latest_Allocated_Node->next->block.address < newListNode->block.address)
                {
                    latest_Allocated_Node = latest_Allocated_Node->next;
                }
                newListNode->next = latest_Allocated_Node->next;
                latest_Allocated_Node->next = newListNode;
            }
            else{

                throw Exception(EINVAL, __func__);
            }

            // Return: The start address of the block allocated -> Como pedido na página html
            return newListNode->block.address;
        }

        // ================================================================================== //

    } // end of namespace group

