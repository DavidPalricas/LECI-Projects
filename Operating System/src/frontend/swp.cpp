/*
 *  \author Artur Pereira (artur at ua dot pt)
 */

#include "swp.h"

#include <stdio.h>
#include <stdint.h>

// ================================================================================== //

/**
 * \brief Set of processes that will arrive to the system
 */
SwpNode *swpHead = NULL;    ///< Pointer to head of list
SwpNode *swpTail = NULL;    ///< Pointer to tail of list

// ================================================================================== //

namespace binaries {
    void swpInit();
    void swpTerm();
    void swpPrint(FILE *fout);
    void swpAdd(uint32_t pid, AddressSpaceProfile *profile);
    SwappedProcess *swpPeek(uint32_t idx);
    void swpRemove(uint32_t idx);
}

namespace group {
    void swpInit();
    void swpTerm();
    void swpPrint(FILE *fout);
    void swpAdd(uint32_t pid, AddressSpaceProfile *profile);
    SwappedProcess *swpPeek(uint32_t idx);
    void swpRemove(uint32_t idx);
}

// ================================================================================== //

void swpInit()
{
    if (soBinSelected(401))
        binaries::swpInit();
    else
        group::swpInit();
}

// ================================================================================== //

void swpTerm()
{
    if (soBinSelected(402))
        binaries::swpTerm();
    else
        group::swpTerm();
}

// ================================================================================== //

void swpPrint(FILE *fout)
{
    if (soBinSelected(403))
        binaries::swpPrint(fout);
    else
        group::swpPrint(fout);
}

// ================================================================================== //

void swpAdd(uint32_t pid, AddressSpaceProfile *profile)
{
    if (soBinSelected(404))
        binaries::swpAdd(pid, profile);
    else
        group::swpAdd(pid, profile);
}

// ================================================================================== //

SwappedProcess *swpPeek(uint32_t idx)
{
    if (soBinSelected(405))
        return binaries::swpPeek(idx);
    else
        return group::swpPeek(idx);
}

// ================================================================================== //

void swpRemove(uint32_t idx)
{
    if (soBinSelected(406))
        return binaries::swpRemove(idx);
    else
        return group::swpRemove(idx);
}

// ================================================================================== //

