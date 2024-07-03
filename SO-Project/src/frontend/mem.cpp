/*
 *  \author Artur Pereira (artur at ua dot pt)
 */

#include "mem.h"

#include <stdio.h>
#include <stdint.h>

// ================================================================================== //

/*
 * The set of supporting variables are NOT changeable
 */
MemParameters memParameters;    ///< Global memory management parameters

MemListNode *memFreeHead;       ///< Head of the free list for first fit algorithm
MemListNode *memOccupiedHead;   ///< Head of the occupied list for first fit algorithm

MemTreeNode *memTreeRoot;       ///< Root of the buddy system tree

// ================================================================================== //

namespace binaries {
    void memInit(uint32_t memSize, uint32_t memSizeOS, uint32_t chunkSize, AllocationPolicy policy);
    void memTerm();
    void memPrint(FILE *fout);
    AddressSpaceMapping *memAlloc(uint32_t pid, AddressSpaceProfile *profile);
    Address memFirstFitAlloc(uint32_t pid, uint32_t size);
    Address memBuddySystemAlloc(uint32_t pid, uint32_t size);
    void memFree(AddressSpaceMapping *mapping);
    void memFirstFitFree(Address address);
    void memBuddySystemFree(Address address);
}

namespace group {
    void memInit(uint32_t memSize, uint32_t memSizeOS, uint32_t chunkSize, AllocationPolicy policy);
    void memTerm();
    void memPrint(FILE *fout);
    AddressSpaceMapping *memAlloc(uint32_t pid, AddressSpaceProfile *profile);
    Address memFirstFitAlloc(uint32_t pid, uint32_t size);
    Address memBuddySystemAlloc(uint32_t pid, uint32_t size);
    void memFree(AddressSpaceMapping *mapping);
    void memFirstFitFree(Address address);
    void memBuddySystemFree(Address address);
}

// ================================================================================== //

void memInit(uint32_t memSize, uint32_t memSizeOS, uint32_t chunkSize, AllocationPolicy policy)
{
    if (soBinSelected(501))
        binaries::memInit(memSize, memSizeOS, chunkSize, policy);
    else
        group::memInit(memSize, memSizeOS, chunkSize, policy);
}

// ================================================================================== //

void memTerm()
{
    if (soBinSelected(502))
        binaries::memTerm();
    else
        group::memTerm();
}

// ================================================================================== //

void memPrint(FILE *fout)
{
    if (soBinSelected(503))
        binaries::memPrint(fout);
    else
        group::memPrint(fout);
}

// ================================================================================== //

AddressSpaceMapping *memAlloc(uint32_t pid, AddressSpaceProfile *profile)
{
    if (soBinSelected(504))
        return binaries::memAlloc(pid, profile);
    else
        return group::memAlloc(pid, profile);
}

// ================================================================================== //

Address memFirstFitAlloc(uint32_t pid, uint32_t size)
{
    if (soBinSelected(505))
        return binaries::memFirstFitAlloc(pid, size);
    else
        return group::memFirstFitAlloc(pid, size);
}

// ================================================================================== //

Address memBuddySystemAlloc(uint32_t pid, uint32_t size)
{
    if (soBinSelected(506))
        return binaries::memBuddySystemAlloc(pid, size);
    else
        return group::memBuddySystemAlloc(pid, size);
}

// ================================================================================== //

void memFree(AddressSpaceMapping *mapping)
{
    if (soBinSelected(507))
        binaries::memFree(mapping);
    else
        group::memFree(mapping);
}

// ================================================================================== //

void memFirstFitFree(Address address)
{
    if (soBinSelected(508))
        binaries::memFirstFitFree(address);
    else
        group::memFirstFitFree(address);
}

// ================================================================================== //

void memBuddySystemFree(Address address)
{
    if (soBinSelected(509))
        binaries::memBuddySystemFree(address);
    else
        group::memBuddySystemFree(address);
}

// ================================================================================== //

