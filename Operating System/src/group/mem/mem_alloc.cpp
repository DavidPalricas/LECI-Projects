/*
 *  \author     David Palricas nº 108780
                Eduardo Alves nº 104179
                Mariana Silva nº 98392
 */

#include "somm23.h"

#include <stdint.h>

namespace group 
{

// ================================================================================== //

    uint32_t correct_mem2(uint32_t buddy_mem_size) {
        
     
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

    AddressSpaceMapping *memAlloc(uint32_t pid, AddressSpaceProfile *profile){
        soProbe(504, "%s(%u, %p)\n", __func__, pid, profile);

        require(pid > 0, "process ID must be non-zero");
        require(profile != NULL, "profile must be a valid pointer to an AddressSpaceProfile variable");

        /* The mapping to be filled and whose pointer should be returned */
        /* TODO POINT: Replace next instructions with your code */
        
        // Instanciação das variáveis
        static AddressSpaceMapping Mapping = {0, {0}};
        u_int32_t total_size_needed = 0;

        // Se usar o First Fit algorithm
        if(memParameters.policy == FirstFit){
            for (uint32_t i = 0; i < profile->segmentCount; ++i){
                // Calcular o tamanho necessário para cada segmento
                uint32_t usable_size = (profile->size[i] + memParameters.chunkSize - 1) / (memParameters.chunkSize);
                total_size_needed = total_size_needed + usable_size;

                //Alocar memória com o FirstFit
                Mapping.address[i] = memFirstFitAlloc(pid, usable_size);

                    
                // No caso da alocação falhar, liberta a memória previamente alocada and e retorna NULL_ADDRESS
                if (Mapping.address[i] == NULL_ADDRESS){
                    for (uint32_t k = 0; k < i; ++k){
                        memFirstFitFree(Mapping.address[k]);
                    }
                    return NO_MAPPING;
                }
            }
            
            // Se usar o Buddy System algorithm
        }else if (memParameters.policy == BuddySystem){
            for (uint32_t i = 0; i < profile->segmentCount; ++i){
                // Calcular o tamanho necessário para cada segmento
                uint32_t  usable_size = (profile->size[i] + memParameters.chunkSize - 1) / memParameters.chunkSize;
                usable_size = correct_mem2(usable_size);
                total_size_needed = total_size_needed + usable_size;

                //Alocar memória com o BuddySystem
                Mapping.address[i] = memBuddySystemAlloc(pid, usable_size);

                if (Mapping.address[i] == NULL_ADDRESS){
                    for (uint32_t k = 0; k < i; ++k){
                        memBuddySystemFree(Mapping.address[k]);
                    }
                    return NO_MAPPING;
                }
            }
        
        }else {
            throw Exception(EINVAL, __func__);
        }

            // Verifica se a memória necessária é maior que a memória total
        if(total_size_needed > memParameters.totalSize){
            return IMPOSSIBLE_MAPPING;
        }

        Mapping.blockCount = profile->segmentCount;
        return &Mapping;
    }
} 




// ================================================================================== //
 // end of namespace group

