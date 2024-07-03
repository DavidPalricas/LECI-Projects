/*
 *  \author Artur Pereira (artur at ua dot pt)
 */

#include "somm23.h"

#include <stdio.h>
#include <stdint.h>

// ================================================================================== //

/*
 * The set of supporting variables are NOT changeable
 */
uint32_t stepCount;                  ///< The current number of simulation steps
uint32_t simTime;                    ///< The current simulation time
ForthcomingTable forthcomingTable;   ///< The set of processes to be simulated

// ================================================================================== //
// ================================================================================== //

namespace binaries {
    void simInit(uint32_t memSize, uint32_t memSizeOS, uint32_t chunkSize, AllocationPolicy policy);
    void simTerm();
    void simLoad(const char *fname);
    void simRandomFill(uint32_t n, uint32_t seed);
    void simPrint(FILE *fout);
    ForthcomingProcess *simGetProcess(uint32_t pid);
    bool simStep();
    void simRun(uint32_t cnt);
}

namespace group {
    void simInit(uint32_t memSize, uint32_t memSizeOS, uint32_t chunkSize, AllocationPolicy policy);
    void simTerm();
    void simLoad(const char *fname);
    void simRandomFill(uint32_t n, uint32_t seed);
    void simPrint(FILE *fout);
    ForthcomingProcess *simGetProcess(uint32_t pid);
    bool simStep();
    void simRun(uint32_t cnt);
}

// ================================================================================== //

void simInit(uint32_t memSize, uint32_t memSizeOS, uint32_t chunkSize, AllocationPolicy policy)
{
    if (soBinSelected(101))
        binaries::simInit(memSize, memSizeOS, chunkSize, policy);
    else
        group::simInit(memSize, memSizeOS, chunkSize, policy);
}

// ================================================================================== //

void simTerm()
{
    if (soBinSelected(102))
        binaries::simTerm();
    else
        group::simTerm();
}

// ================================================================================== //

void simPrint(FILE *fout)
{
    if (soBinSelected(103))
        binaries::simPrint(fout);
    else
        group::simPrint(fout);
}

// ================================================================================== //

void simLoad(const char *fname)
{
    if (soBinSelected(104))
        binaries::simLoad(fname);
    else
        group::simLoad(fname);
}

// ================================================================================== //

void simRandomFill(uint32_t n, uint32_t seed)
{
    if (soBinSelected(105))
        binaries::simRandomFill(n, seed);
    else
        group::simRandomFill(n, seed);
}

// ================================================================================== //

ForthcomingProcess *simGetProcess(uint32_t pid)
{
    if (soBinSelected(106))
        return binaries::simGetProcess(pid);
    else
        return group::simGetProcess(pid);
}

// ================================================================================== //

bool simStep()
{
    if (soBinSelected(107))
        return binaries::simStep();
    else
        return group::simStep();
}

// ================================================================================== //

void simRun(uint32_t cnt)
{
    if (soBinSelected(108))
        binaries::simRun(cnt);
    else
        group::simRun(cnt);
}

// ================================================================================== //

