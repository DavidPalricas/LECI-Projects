/*
 *  \author Artur Pereira (artur at ua dot pt)
 */

#include "pct.h"

#include <stdio.h>
#include <stdint.h>

// ================================================================================== //

/*
 * The set of supporting variables are NOT changeable
 */
PctNode *pctHead;    ///< Pointer to head of list 

// ================================================================================== //

namespace binaries {
    void pctInit();
    void pctTerm();
    void pctPrint(FILE *fout);
    void pctInsert(uint32_t pid, uint32_t time, uint32_t lifetime, AddressSpaceProfile *memProfile);
    uint32_t pctGetLifetime(uint32_t pid);
    AddressSpaceProfile *pctGetAddressSpaceProfile(uint32_t pid);
    AddressSpaceMapping *pctGetAddressSpaceMapping(uint32_t pid);
    const char *pctGetStateAsString(uint32_t pid);
    void pctUpdateState(uint32_t pid, ProcessState state, uint32_t time, AddressSpaceMapping *mapping);
}

namespace group {
    void pctInit();
    void pctTerm();
    void pctPrint(FILE *fout);
    void pctInsert(uint32_t pid, uint32_t time, uint32_t lifetime, AddressSpaceProfile *memProfile);
    uint32_t pctGetLifetime(uint32_t pid);
    AddressSpaceProfile *pctGetAddressSpaceProfile(uint32_t pid);
    AddressSpaceMapping *pctGetAddressSpaceMapping(uint32_t pid);
    const char *pctGetStateAsString(uint32_t pid);
    void pctUpdateState(uint32_t pid, ProcessState state, uint32_t time, AddressSpaceMapping *mapping);
}

// ================================================================================== //

void pctInit()
{
    if (soBinSelected(301))
        binaries::pctInit();
    else
        group::pctInit();
}

// ================================================================================== //

void pctTerm()
{
    if (soBinSelected(302))
        binaries::pctTerm();
    else
        group::pctTerm();
}

// ================================================================================== //

void pctPrint(FILE *fout)
{
    if (soBinSelected(303))
        binaries::pctPrint(fout);
    else
        group::pctPrint(fout);
}

// ================================================================================== //

void pctInsert(uint32_t pid, uint32_t time, uint32_t lifetime, AddressSpaceProfile *profile)
{
    if (soBinSelected(304))
        binaries::pctInsert(pid, time, lifetime, profile);
    else
        group::pctInsert(pid, time, lifetime, profile);
}

// ================================================================================== //

uint32_t pctGetLifetime(uint32_t pid)
{
    if (soBinSelected(305))
        return binaries::pctGetLifetime(pid);
    else
        return group::pctGetLifetime(pid);
}

// ================================================================================== //

AddressSpaceProfile *pctGetAddressSpaceProfile(uint32_t pid)
{
    if (soBinSelected(306))
        return binaries::pctGetAddressSpaceProfile(pid);
    else
        return group::pctGetAddressSpaceProfile(pid);
}

// ================================================================================== //

AddressSpaceMapping *pctGetAddressSpaceMapping(uint32_t pid)
{
    if (soBinSelected(307))
        return binaries::pctGetAddressSpaceMapping(pid);
    else
        return group::pctGetAddressSpaceMapping(pid);
}

// ================================================================================== //

const char *pctGetStateAsString(uint32_t pid)
{
    if (soBinSelected(308))
        return binaries::pctGetStateAsString(pid);
    else
        return group::pctGetStateAsString(pid);
}

// ================================================================================== //

void pctUpdateState(uint32_t pid, ProcessState state, uint32_t time, AddressSpaceMapping *mapping)
{
    if (soBinSelected(309))
        binaries::pctUpdateState(pid, state, time, mapping);
    else
        group::pctUpdateState(pid, state, time, mapping);
}

// ================================================================================== //

