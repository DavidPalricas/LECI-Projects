/*
 *  \author Rúben Lopes 103009, Inês Santos 103477        
 */

#include "somm23.h"

namespace group
{

// ================================================================================== //

    void simLoad(const char *fname)
    {
        soProbe(104, "%s(\"%s\")\n", __func__, fname);

        require(fname != NULL, "fname can not be a NULL pointer");
        require(forthcomingTable.count == 0, "Forthcoming table should be empty");

        FILE *file = fopen(fname, "r");
        if (file == NULL) {
            printf("Error opening file!\n");
            throw Exception(errno, __func__);
        }

        char* line = NULL;
        size_t lineLength = 0;
        uint32_t result;

        uint32_t pid;
        uint32_t lifetime;
        uint32_t arrivalTime;

        while (getline(&line, &lineLength, file) != -1) {
            
            size_t index = 0;

            while (line[index] == ' ' || line[index] == '\t' || line[index] == '\n' || line[index] == '\r' || line[index] == '\f' || line[index] == '\v') {
                index++;
            }
            
            if (line[index] == '%' || line[index] == '\0') continue; 
            
            uint32_t size[MAX_SEGMENTS] = {0, 0, 0, 0};

            result = sscanf(line, " %u ; %u ; %u ; %u , %u , %u , %u", &pid, &arrivalTime, &lifetime, &size[0], &size[1], &size[2], &size[3]);

            // printf("READ LINE : %s\n", line); //Debug print line by line of the file read
            // printf("pid: %u\n", pid);
            // printf("arrivalTime: %u\n", arrivalTime);
            // printf("lifetime: %u\n", lifetime);
            // printf("size[0]: %u\n", size[0]);
            // printf("size[1]: %u\n", size[1]);
            // printf("size[2]: %u\n", size[2]);
            // printf("size[3]: %u\n", size[3]);

            if (result < 3) {
                printf("Error parsing line!\n");
                throw Exception(EINVAL, __func__);
            }

            for(uint32_t k = 0; k < forthcomingTable.count; k++){
                if(forthcomingTable.process[k].pid == pid){
                    printf("PID already exists!\n");
                    throw Exception(EINVAL, __func__);
                }
            } 

            if(forthcomingTable.process[forthcomingTable.count].arrivalTime > arrivalTime){
                    printf("Error on the arrival time!\n");
                    throw Exception(EINVAL, __func__);
                }

            if(lifetime <= 0){
                    printf("Error on the lifetime!\n");
                    throw Exception(EINVAL, __func__);
                }

            forthcomingTable.process[forthcomingTable.count].pid = pid;
            forthcomingTable.process[forthcomingTable.count].lifetime = lifetime;
            forthcomingTable.process[forthcomingTable.count].arrivalTime = arrivalTime;
            forthcomingTable.process[forthcomingTable.count].addressSpace.segmentCount = result - 3;
            forthcomingTable.process[forthcomingTable.count].addressSpace.size[0] = size[0];
            forthcomingTable.process[forthcomingTable.count].addressSpace.size[1] = size[1];
            forthcomingTable.process[forthcomingTable.count].addressSpace.size[2] = size[2];
            forthcomingTable.process[forthcomingTable.count].addressSpace.size[3] = size[3];
            forthcomingTable.count++;            
            feqInsert(ARRIVAL, arrivalTime, pid);       // insert in the event queue
            free(line);
        }
        fclose(file);

    }

// ================================================================================== //

} // end of namespace group

