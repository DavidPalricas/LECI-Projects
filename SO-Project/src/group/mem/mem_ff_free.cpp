/*
 *  \author ... Eduardo Alves nº 104179
                David Palricas nº 108780
                Mariana Silva nº 98392
 */

#include "somm23.h"

#include <stdint.h>

namespace group 
{

// ================================================================================== //

    void memFirstFitFree(Address address) {
    soProbe(508, "%s(%u)\n", __func__, address);

    require(memOccupiedHead != nullptr, "Occupied list should contain nodes");

    // Verificar se o endereço que queremos encontrar existe e não é nulo.
    if (address == NULL_ADDRESS) {
        throw Exception(EINVAL, __func__);
    }

    // Instanciação de Nodes
    MemListNode *current = memOccupiedHead;
    MemListNode *previous_node = nullptr;

    // Procurar pelo Node com o endereço pretendido
    while (current != nullptr) {

        if (current->block.address == address) {
            // Marcar o pid do bloco descoberto como 0, para atribuirmos como free
            current->block.pid = 0;

            // Remover o bloco da lista ocupada para mais tarde colocar na lista livre
            if (previous_node != nullptr) {
                previous_node->next = current->next;
            } else {
                memOccupiedHead = current->next;
            }

            // Colocar o bloco dentro da lista livre por ordem ascendente de endereços
            MemListNode *free_current = memFreeHead;
            MemListNode *free_previous_node = nullptr;

            while (free_current != nullptr && free_current->block.address < current->block.address) {
                free_previous_node = free_current;
                free_current = free_current->next;
            }

            if (free_previous_node != nullptr) {
                free_previous_node->next = current;
            } else {
                memFreeHead = current;
            }

            current->next = free_current;
            current->prev = free_previous_node;
            if (free_current != nullptr) {
                free_current->prev = current;
            }

            // Merge com o bloco seguinte dentro da lista de Nodes livre
            if (current->next != nullptr && current->block.address + current->block.size == current->next->block.address) {
                current->block.size = current->block.size + current->next->block.size;
                MemListNode *temp = current->next;
                current->next = current->next->next;
                if (current->next != nullptr) {
                    current->next->prev = current;
                }
                delete temp;
            }

            // Merge com o bloco anterior dentro da lista de Nodes livre
            if (current->prev != nullptr && current->prev->block.address + current->prev->block.size == current->block.address) {
                current->prev->block.size = current->prev->block.size + current->block.size;
                current->prev->next = current->next;
                if (current->next != nullptr) {
                    current->next->prev = current->prev;
                }
                delete current;
            }
            return;
        }

        previous_node = current;
        current = current->next;
    }
}
}