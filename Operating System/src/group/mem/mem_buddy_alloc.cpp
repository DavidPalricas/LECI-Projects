/*
 *  \author David Palricas 108780
    \author Eduardo Alves 104179
 */


#include "somm23.h"

#include <stdint.h>

namespace group 

{  void  split_block(MemTreeNode * current){

                        //Criação dos nós filhos

      current->state = SPLITTED; //O nó pai passa a estar dividido em dois nós filhos

      MemTreeNode * left_child =  new MemTreeNode; //Criação do nó filho esquerdo

      MemTreeNode *right_child = new MemTreeNode; //Criação do nó filho direito


                  //Atribuição dos valores do nó filho esquerdo
      left_child->state = FREE;
      left_child->block.pid = 0; //Se o pid é 0 indica que o bloco está livre
      left_child->block.size = current->block.size/2; //O tamanho do filho esquerdo é metade do tamanho do pai
      left_child->block.address = current->block.address; //O endereço do filho esquerdo é igual ao endereço do pai
      left_child->left = nullptr; //O filho esquerdo do filho esquerdo é nulo
      left_child->right = nullptr; //O filho direito do filho esquerdo é nulo
     
      
            //Atribuição dos valores do nó filho direito
      right_child->state = FREE;
      right_child->block.pid = 0; //Se o pid é 0 indica que o bloco está livre
      right_child->block.size = current->block.size/2; //O tamanho do filho direito é metade do tamanho do pai
      right_child->block.address = left_child->block.address + (current->block.size/2); //O endereço do filho direito é igual ao endereço do pai + metade do tamanho do pai
      right_child->left = nullptr; //O filho esquerdo do filho direito é nulo
      right_child->right = nullptr; //O filho direito do filho direito é nulos
     

                            //Update ao nó pai
      current->left = left_child; //O nó pai aponta para o filho esquerdo
      current->right = right_child; //O nó pai aponta para o filho direito
    }
    


    bool allocate_conditions(uint32_t size,uint32_t current_size){
        if (size > (current_size / 2) || size == current_size )
        {
            return true;
        }
        return false;

    }

   MemTreeNode *DFS(MemTreeNode *current, uint32_t size, uint32_t pid, MemTreeNode *parent){
    bool to_allocate = false;

    if (current == nullptr || size > current->block.size) // Check if the current node is nullptr
    {
        return nullptr;
    }
   
    switch (current->state)
    {
    case FREE:{
            if (parent != nullptr) // Caso o nó pai não seja nulo
            { 
                if (current == parent->left)  
                { // Caso o endereço do filho esquerdo seja maior que o endereço do filho direito
                    to_allocate = allocate_conditions(size, current->block.size);
                    
                }
                else if (current == parent->right)
                {   if (parent->left->state == OCCUPIED || parent->left->state == SPLITTED){

                      to_allocate = allocate_conditions(size, current->block.size);
                    }
                   
                }
            }
            else
            {
                to_allocate = allocate_conditions(size, current->block.size);
            }

          

      
            
            if (to_allocate ==true){
                current->block.pid = pid;
                current->state = OCCUPIED;
                return current;
            }
               
               
            split_block(current);
            DFS(current->left, size, pid, current);
            
            break;
        
          
    }
    
  
    case SPLITTED:{
           if (current->left->state == OCCUPIED && size > current->block.size /2 )
           {
              DFS(parent->right, size, pid,parent);
           }
           
           
           
           
            DFS(current->left, size, pid, current);
           
            break;
        
             
    
    }

    case OCCUPIED:{
            DFS(parent->right, size, pid, parent);
           
            break;
    }
    
       
    
    default: {
       
        break;
    }

   
  
    }

    return nullptr; // Return nullptr if no block is found
}




    

// ================================================================================== //

    Address memBuddySystemAlloc(uint32_t pid, uint32_t size)
    {
        soProbe(506, "%s(%u, %#x)\n", __func__, pid, size);

        require(pid > 0, "a valid process ID must be greater than zero");
        require(size, "the size of a memory segment must be greater then zero");

        
        

        /* TODO POINT: Replace next instruction with your code */

        MemTreeNode *current = memTreeRoot; //Aponta para a raiz da árvore



        MemTreeNode *node =  DFS(current, size,pid,nullptr); //Procura o primeiro bloco livre que tenha o tamanho desejado ou maior
                                                             //O parent node da raíz é nulo
        if (node != nullptr) {
            return node->block.address; // Return the address of the allocated block
        }
      
        return NULL_ADDRESS; // Return NULL_ADDRESS if no block is found
        
  
     
            
        //throw Exception(ENOSYS, __func__);
    }

// ================================================================================== //

} // end of namespace group