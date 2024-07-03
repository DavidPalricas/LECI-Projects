/*
 *  \author Eduardo Alves: nº104179, David Palricas: nº108780, Mariana Silva: nº98392
 */

#include "somm23.h"

namespace group
{

// ================================================================================== //

    void swpRemove(uint32_t idx)
    {
        soProbe(406, "%s(%u)\n", __func__, idx);

        /* TODO POINT: Replace next instruction with your code */

        /*Verifica se o index está dentro do limite*/

        if (swpHead == nullptr){ /*Verificar este tipo de exception*/
            throw Exception(EINVAL, __func__);
        }

        /*Se escolhermos apagar o primeiro elemento da lista ligada (Head)*/
        if (idx == 0){
            SwpNode* temp = swpHead; /*Temos que instanciar um Node temporario de forma a eliminar a informação do primeiro Node mas passar o Head para o próximo Node, de forma a haver sempre um Head*/
            swpHead = swpHead->next; /*Aqui estamos a atribuir ao proximo Node o titulo de Head, pois o primeiro Node vai ser eliminado*/
            delete temp; /*Elimimar o Node, removendo assim a memória alocada para ele*/
            return;
        }

        /*Instanciação do current e do current index*/
        SwpNode* current = swpHead; /*Instanciar o current que vai ser iterado no while como o primeiro elemento da lista ligada*/
        SwpNode* previous = nullptr; /*Instanciar o previous como Null, já que antes da Head náo existem Nodes */
        uint32_t currentidx = 0;

        while (current->next != nullptr && currentidx < idx){
            /* code */
            previous = current;
            current = current->next;
            currentidx++;
        }

        if(current == nullptr || currentidx != idx){
            throw Exception(EINVAL, __func__);
        }

        /*Faz a ligação da linked list do Node anterior ao que pretendemos remover com o que vem a seguir ao que pretendemos remover, cortando a ligação do Node que queremos remover */
        previous->next = current->next;
        /* Liberta as memorias alocadas para cada um das informações armazenadas no Node a remover*/
        delete current;
    }

// ================================================================================== //

} // end of namespace group

