/*
 *  \author: Mariana Silva 98392 
 */

#include "somm23.h"
#include <stdint.h>

namespace group {

    MemTreeNode *findBlockByAddress(MemTreeNode *current, Address address) {
        if (current == nullptr) {
            return nullptr;
        }

        if (current->block.address == address && current->state == OCCUPIED) {
            return current;
        }

        MemTreeNode *leftResult = findBlockByAddress(current->left, address);
        MemTreeNode *rightResult = findBlockByAddress(current->right, address);

        return (leftResult != nullptr) ? leftResult : rightResult;
    }

 MemTreeNode *getParent(MemTreeNode *current, MemTreeNode *child) {
        if (current == nullptr || (current->left != child && current->right != child)) {
            return nullptr;
        }

        return current;
    }

    void mergeBlocks(MemTreeNode *&root, MemTreeNode *current) {
    if (current == nullptr || current->state != FREE) {
        return;
    }

    MemTreeNode *parent = getParent(root, current);

    switch (current->state) {
        case OCCUPIED:
            current->block.pid = 0;
            current->state = FREE;
            break;

        case SPLITTED:
            mergeBlocks(root, parent);
            current->state = FREE;
            break;

        case FREE:
            mergeBlocks(root, parent);
            return;
    }

    if (parent != nullptr && parent->state == FREE) {
        MemTreeNode *sibling = (parent->left == current) ? parent->right : parent->left;
        if (sibling != nullptr && sibling->state == FREE) {

            parent->block.size = sibling->block.size + current->block.size; 
            parent->state = OCCUPIED;

            if (parent->left == current) {
                parent->left = nullptr;
            } else {
                parent->right = nullptr;
            }
            delete current;
            delete sibling;
            mergeBlocks(root, parent);
        }
    } else if (current == root && current->state == FREE) {
        root = nullptr;
    }
}



    void memBuddySystemFree(Address address) {
        soProbe(509, "%s(%#x)\n", __func__, address);

        require(address != NULL_ADDRESS, "invalid address");

        MemTreeNode *current = memTreeRoot; 
        MemTreeNode *node = findBlockByAddress(current, address); 

        if (node != nullptr && node->state == OCCUPIED) {
            node->block.pid = 0;
            node->state = FREE;
            mergeBlocks(memTreeRoot, node);
        }
    }
}// end of namespace group
